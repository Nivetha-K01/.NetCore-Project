using Microsoft.AspNetCore.Mvc;
using PJAverageRate.Models;
using System.Data;

namespace PJAverageRate.Services
{
    public interface IpjAveragerateService
    {
        Task<DataSet> GetAverageRate(PJAverageRateViewModel model);

        Task<DataSet> GettablesData(PJAverageRateViewModel model);
    }
}
