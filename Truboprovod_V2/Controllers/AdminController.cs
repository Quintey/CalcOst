using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Truboprovod_V2.Models;
using MvcRazorToPdf;
using SysIO = System.IO;

namespace Truboprovod_V2.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "admin")]
        public ActionResult Administr()
        {
            return  View();
        }


        // GET: Admin
       
        [Authorize(Roles = "admin")]
        public ActionResult AdministrPdf()
        {
            
            return new  PdfActionResult("AdministrPdf");
        } 
    }
}