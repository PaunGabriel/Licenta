using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Data.SqlClient;
//using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SpinIt.RightAPI.DataBase
{
    public class Connection
    {
        public IConfiguration Configuration { get; }
        
        public SqlConnection GetConnection()
        {
            //Configuration.GetConnectionString("DefaultConnection")


            //SqlConnection conn = new SqlConnection("data source=103.31.82.199,1433;initial catalog=PPHI.standardLab;user id=dev;password=123PPHI!@#;");
            //SqlConnection conn = new SqlConnection("Data Source = SQL5079.site4now.net; Initial Catalog = db_a42557_uniapi; Persist Security Info = True; User ID = db_a42557_uniapi_admin; Password = Admin@123");
            SqlConnection conn = new SqlConnection("Data Source = SQL5079.site4now.net; Initial Catalog = db_a7e985_hoolif; Persist Security Info = True; User ID = db_a7e985_hoolif_admin; Password = Admin@123");

            return conn;
        }
    }
}