using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PJAverageRate.Data;
using System.Data;
using System.Globalization;
//using Microsoft.Data.SqlClient;

namespace PJAverageRate.Repository
{
    public class pjAveragerateRepo : IpjAverageRateRepo
    {

        private AppDbContext _context;
        public pjAveragerateRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DataSet> GetAverageRate(

          string Modeall,
          string unit,
          string company,
          string date,
          string customerType,
         decimal? ltv,
         string goldRateXml)
        {
            using var command = _context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "Loln_SpPJAVgRate_Bulk";
            command.CommandType = CommandType.StoredProcedure;

            if (Modeall == "ADD" || Modeall == "Modify")
            {
                command.Parameters.Add(new SqlParameter("@p_LvQueryXML", SqlDbType.NVarChar)
                {
                    Value = goldRateXml
                });

                //command.Parameters.AddWithValue("@p_LvQueryXML", goldRateXml);
                DateTime dte = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                command.Parameters.Add(new SqlParameter("@Unit", "ALLRG"));
                command.Parameters.Add(new SqlParameter("@compdesc", company));
                command.Parameters.Add(new SqlParameter("@Date", dte.ToString("MM/dd/yyyy")));
                command.Parameters.Add(new SqlParameter("@crtdby", "svs0p005"));
                command.Parameters.Add(new SqlParameter("@statflg", "L"));
                command.Parameters.Add(new SqlParameter("@mode", Modeall));
                command.Parameters.Add(new SqlParameter("@mode1", "L"));
                command.Parameters.Add(new SqlParameter("@maxprcnt", ltv));
                command.Parameters.Add(new SqlParameter("@custtype", customerType));
                command.Parameters.Add(new SqlParameter("@unitshrtdescr", unit));

            }
            else if (Modeall == "DeActivate")
            {
                command.Parameters.Add(new SqlParameter("@p_LvQueryXML", SqlDbType.NVarChar)
                {
                    Value = goldRateXml
                });

                //command.Parameters.AddWithValue("@p_LvQueryXML", goldRateXml);
                DateTime dte = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                command.Parameters.Add(new SqlParameter("@Unit", "ALLRG"));
                command.Parameters.Add(new SqlParameter("@compdesc", company));
                command.Parameters.Add(new SqlParameter("@Date", dte.ToString("MM/dd/yyyy")));
                command.Parameters.Add(new SqlParameter("@crtdby", "svs0p005"));
                command.Parameters.Add(new SqlParameter("@statflg", "D"));
                command.Parameters.Add(new SqlParameter("@mode", Modeall));
                command.Parameters.Add(new SqlParameter("@mode1", "L"));
                command.Parameters.Add(new SqlParameter("@maxprcnt", "0"));
                command.Parameters.Add(new SqlParameter("@custtype", customerType));
                command.Parameters.Add(new SqlParameter("@unitshrtdescr", unit));

            }
            else if (Modeall == "ReActivate")
            {
                command.Parameters.Add(new SqlParameter("@p_LvQueryXML", SqlDbType.NVarChar)
                {
                    Value = goldRateXml
                });

                //command.Parameters.AddWithValue("@p_LvQueryXML", goldRateXml);
                DateTime dte = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                command.Parameters.Add(new SqlParameter("@Unit", "ALLRG"));
                command.Parameters.Add(new SqlParameter("@compdesc", company));
                command.Parameters.Add(new SqlParameter("@Date", dte.ToString("MM/dd/yyyy")));
                command.Parameters.Add(new SqlParameter("@crtdby", "svs0p005"));
                command.Parameters.Add(new SqlParameter("@statflg", "R"));
                command.Parameters.Add(new SqlParameter("@mode", Modeall));
                command.Parameters.Add(new SqlParameter("@mode1", "L"));
                command.Parameters.Add(new SqlParameter("@maxprcnt", "0"));
                command.Parameters.Add(new SqlParameter("@custtype", customerType));
                command.Parameters.Add(new SqlParameter("@unitshrtdescr", unit));

            }


            await _context.Database.OpenConnectionAsync();


            var ds = new DataSet();

            using (var adapter = new SqlDataAdapter((SqlCommand)command))
            {
                adapter.Fill(ds);
            }


            return ds;
        }

       public async Task<DataSet> GettablesData(string Modeall, string unit, string company, string date, string customerType)
        {
            using var command = _context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "Loln_SpPJAVgRate_Bulk";
            command.CommandType = CommandType.StoredProcedure;

            if (Modeall == "View" || Modeall == "Modify" || Modeall == "DeActivate" || Modeall == "ReActivate")
            {

                //command.Parameters.AddWithValue("@p_LvQueryXML", goldRateXml);
                DateTime dte = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                command.Parameters.Add(new SqlParameter("@Unit", "ALLRG"));
                command.Parameters.Add(new SqlParameter("@compdesc", company));
                command.Parameters.Add(new SqlParameter("@Date", dte.ToString("MM/dd/yyyy")));
                command.Parameters.Add(new SqlParameter("@crtdby", "NULL"));
                command.Parameters.Add(new SqlParameter("@statflg", "NULL"));
                command.Parameters.Add(new SqlParameter("@mode", Modeall));
                command.Parameters.Add(new SqlParameter("@mode1", "G"));
                command.Parameters.Add(new SqlParameter("@maxprcnt", "0"));
                command.Parameters.Add(new SqlParameter("@custtype", customerType));
                command.Parameters.Add(new SqlParameter("@unitshrtdescr", unit));

            }
            

                await _context.Database.OpenConnectionAsync();


            var ds = new DataSet();

            using (var adapter = new SqlDataAdapter((SqlCommand)command))
            {
                adapter.Fill(ds);
            }


            return ds;
        }
    }


}
