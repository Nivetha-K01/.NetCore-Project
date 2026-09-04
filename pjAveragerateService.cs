using Microsoft.AspNetCore.Mvc;
using PJAverageRate.Models;
using PJAverageRate.Repository;
using System.Data;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PJAverageRate.Services
{
    public class pjAveragerateService : IpjAveragerateService
    {
        private readonly IpjAverageRateRepo _repository;

        public pjAveragerateService(IpjAverageRateRepo repository)
        {
            _repository = repository;
        }

        public async Task<DataSet> GetAverageRate(PJAverageRateViewModel model)
        {
            string goldRateXml = GenerateGoldRateXml(model.GoldRates);

            return await _repository.GetAverageRate(

                model.Modeall,
                model.Unit,
                model.Company,
                model.Date,
                model.CustomerType,
                model.Ltv,
                goldRateXml
            );
        }


        private string GenerateGoldRateXml(List<GoldRateModel> goldRates)
        {
            //var serializer = new XmlSerializer(typeof(List<GoldRateModel>));

            //using var stringWriter = new StringWriter();

            //serializer.Serialize(stringWriter, goldRates);

            //return stringWriter.ToString();

            var root = new XElement("Root");

            foreach (var g in goldRates)
            {
                var element = new XElement("GoldRate");

                if (g.CaratType.HasValue)
                    element.Add(new XAttribute("CaratType", g.CaratType.Value));

                if (g.RateAvg.HasValue)
                    element.Add(new XAttribute("RateThirtyDaysAvg", g.RateAvg.Value));

                if (g.IbjaRate.HasValue)
                    element.Add(new XAttribute("PreviousDayRateIBJA", g.IbjaRate.Value));

                if (g.FinalMarketRate.HasValue)
                    element.Add(new XAttribute("FinalMarketRate", g.FinalMarketRate.Value));

                root.Add(element);
            }

            return root.ToString();
        }


        public async Task<DataSet> GettablesData(PJAverageRateViewModel model)
        {
            return await _repository.GettablesData( model.Modeall, model.Unit, model.Company,  model.Date, model.CustomerType
           
            );
        }
    }
}
