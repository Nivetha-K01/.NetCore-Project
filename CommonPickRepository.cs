using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Utilities;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using PJAverageRate.Data;
using System;
using System.Data;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PJAverageRate.Repository
{
    public class CommonPickRepository : ICommonPickRepository
    {
        private readonly IConfiguration _configuration;

        public CommonPickRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public DataTable GetPickList(string query)
        {
            DataTable dt = new DataTable();

            string conString =
                _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }


    }
}
