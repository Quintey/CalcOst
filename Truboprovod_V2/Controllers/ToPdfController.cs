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
    public class ToPdfController : Controller
    {
        OstResShirinaContext context = new  OstResShirinaContext();

       public ActionResult ToShirinaPdf()
        {

            return new PdfActionResult(context);
        }
    }
}