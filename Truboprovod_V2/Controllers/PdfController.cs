using MvcRazorToPdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Truboprovod_V2.Models;


namespace Truboprovod_V2.Controllers
{
    public class PdfController : Controller
    {
        [Authorize]
        public ActionResult ToShirinaPdf( )
        {
            double asd = 123;
            int Rh1 = 0;
            int Rh2 = 0;

             List<OstResShirinaModel> testModel = new List<OstResShirinaModel>();

            //string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-Truboprovod_V2-20180323015837.mdf;Initial Catalog=aspnet-Truboprovod_V2-20180323015837;Integrated Security=True;MultipleActiveResultSets=True";
            //using (SqlConnection connect = new SqlConnection(connectionString))
            //{


            //    connect.Open();
            //    string sqslComm = "SELECT koef_m2 FROM [Usloviya_neSer] WHERE Category='II'";
            //    SqlCommand comm = new SqlCommand(sqslComm, connect);
            //    SqlDataReader read = comm.ExecuteReader();
            //    while (read.Read())
            //    {
            //        asd = (double)read["koef_m2"];
            //    }
            //    connect.Close();
            //}




            //var model = new OstResShirinaModel
            //{
            //    P = asd
            //};

            return new PdfActionResult("ToShirinaPdf", testModel);
        }
    }
}