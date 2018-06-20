﻿
using CalcLibrary;
using MvcRazorToPdf;
using ShirinaCalc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Truboprovod_V2.Models;
using SysIO = System.IO;
using iTextSharp.text;
using System.Web.Hosting;

namespace Truboprovod_V2.Controllers
{
    public class HomeController : Controller
    {
        OstResShirinaContext context = new OstResShirinaContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calcs()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult ToShirinaPdf()
        {
            
            return View( (      context.ShirinaRes.Where( ty => ty.Id == (context.ShirinaRes.Max( n=>n.Id )))      ).ToList());

            
        }

        public ActionResult ToShirinaPdfRotativa()
        {

            return new Rotativa.ActionAsPdf("ToShirinaPdf", (context.ShirinaRes.Where(ty => ty.Id == (context.ShirinaRes.Max(n => n.Id)))).ToList()) { FileName = "CalculationResult.pdf" };


        }




        [Authorize]
        public ActionResult OstResCalc( )
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult OstResCalc(string arg1, string Dh, string arg3, string arg4,
                                      string arg5, string arg6, string arg7, string arg8,
                                      string serovodorod, string Yf, string P, string R2,
                                      string R1, string m2, string Ym, string Yn, string Ys)
        {
            if (ModelState.IsValid)
            {

                double result;
                double serka = Convert.ToDouble(serovodorod);

                if (serka == 1)
                {
                    Ys = "0";
                }

                if (!double.IsNaN(result = Math.Round(CalcLibrary.Class1.Ostatok(Convert.ToDouble(double.Parse(arg4)),
                                                                         Convert.ToDouble(double.Parse(Yf)),
                                                                         Convert.ToDouble(double.Parse(P)),
                                                                         Convert.ToDouble(double.Parse(Dh)),
                                                                         Convert.ToDouble(double.Parse(serovodorod)),
                                                                         Convert.ToDouble(double.Parse(R2)),
                                                                         Convert.ToDouble(double.Parse(R1)),
                                                                         Convert.ToDouble(double.Parse(m2)),
                                                                         Convert.ToDouble(double.Parse(Ym)),
                                                                         Convert.ToDouble(double.Parse(Yn)),
                                                                         Convert.ToDouble(double.Parse(Ys)),
                                                                         Convert.ToDouble(double.Parse(arg3)),
                                                                         Convert.ToDouble(double.Parse(arg8)),
                                                                         Convert.ToDouble(double.Parse(arg1)),
                                                                         Convert.ToDouble(double.Parse(arg7)),
                                                                         Convert.ToDouble(double.Parse(arg5)),
                                                                         Convert.ToDouble(double.Parse(arg6))), 2)))
                {

                    ViewBag.result = result;
                }
            }

            return PartialView("PartialOstResCalc");
        }



        [Authorize]
        public ActionResult OstResShirinaCalc()
        {
            return View();
        }
      

        [Authorize]
        [HttpPost]
        public ActionResult OstResShirinaCalc(List<double> DynamicExtraField, string Sreda, string Material, double Nominal_tolshina,
                                                                            double P, double Diametr, string Steel, double Narabotka)
        {
            int Rh1 = 0;
            int Rh2 = 0;
            double Sreda_double = 0;
            double Tsr = 0;
            int count = 0;
            string _material="";
            string _sreda = "";

            if (DynamicExtraField != null)
            {
                for (int i = 0; i < DynamicExtraField.Count; i++)
                {
                    Tsr += DynamicExtraField[i];
                    count++;
                }
                Tsr = Tsr / count;
            }

            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-Truboprovod_V2-20180323015837.mdf;Initial Catalog=aspnet-Truboprovod_V2-20180323015837;Integrated Security=True;MultipleActiveResultSets=True";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqslComm = "SELECT R1, R2 FROM [Soprotivleniyas] WHERE Mark='" + Steel + "'";
                SqlCommand comm = new SqlCommand(sqslComm, connect);
                connect.Open();
                SqlDataReader read = comm.ExecuteReader();
                while (read.Read())
                {
                    Rh1 = (int)read["R1"];
                    Rh2 = (int)read["R2"];
                }
                sqslComm = "SELECT koef_m2 FROM [Usloviya_neSer] WHERE Category='" + Sreda + "'";
                comm = new SqlCommand(sqslComm, connect);
                read = comm.ExecuteReader();
                while (read.Read())
                {
                    Sreda_double = (double)read["koef_m2"];
                }
                connect.Close();
            }

            if (ModelState.IsValid)
            {
                ViewBag.Shirinaresult = Math.Round(ShirinaCalc.Class1.OstResurs(DynamicExtraField, Sreda_double, Material, Nominal_tolshina,
                                                                                          P, Diametr, Rh1, Rh2, Narabotka, count, Tsr), 2);


                switch (Material)
                {
                    case "1":
                        _material = "Бесшовные трубы из углеродистой стали";
                        break;

                    case "2":
                        _material = "Сварные трубы из углеродистой стали";
                        break;
                    case "3":
                        _material = "Сварные трубы из низколегированной ненормализованной стали";
                        break;
                    case "4":
                        _material = "Сварных трубы из нормализованной низколегированной стали";
                        break;

                }


                switch (Sreda)
                {
                    case "I":
                        _sreda = "Токсичные, горючие, взрывоопасные и сжиженные газы";
                        break;

                    case "II":
                        _sreda = "инертные газы или токсичные, горючие, взрывоопасные жидкости";
                        break;

                    case "III":
                        _sreda = "инертные жидкости";
                        break;

                }

                double Result = ViewBag.Shirinaresult;

                var claimsIdentity = User.Identity as ClaimsIdentity;

                if (claimsIdentity != null)
                {
                    var userIdClaim = claimsIdentity.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                    if (userIdClaim != null)
                    {
                        var userIdValue = userIdClaim.Value;
                        ViewBag.UserName = User.Identity.Name;
                    }
                    
                    OstResShirinaModel res = new OstResShirinaModel
                    {
                        UserName = User.Identity.Name,
                        Date = DateTime.Now.ToString(),
                        Sreda = _sreda,
                        Material = _material,
                        Nominal_tolshina = Nominal_tolshina,
                        P = P,
                        Diametr = Diametr,
                        Rh1 = Rh1,
                        Rh2 = Rh2,
                        Narabotka = Narabotka,
                        Steel = Steel,
                        OstResult = Result.ToString()
                    };

                    context.ShirinaRes.Add(res);
                    context.SaveChanges();
                }
            }
            return View();
        }
    }
}