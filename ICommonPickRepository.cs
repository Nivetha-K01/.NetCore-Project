using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace PJAverageRate.Repository
{
    public interface ICommonPickRepository
    {
        DataTable GetPickList(string query);

       
    }
}
