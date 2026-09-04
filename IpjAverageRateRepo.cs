using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace PJAverageRate.Repository
{
    public interface IpjAverageRateRepo
    {

        Task<DataSet> GetAverageRate(string Modeall, string unit, string company, string date, string customerType, decimal? ltv, string goldRateXml);

        Task<DataSet> GettablesData(string Modeall, string unit, string company, string date, string customerType);
    }
}
