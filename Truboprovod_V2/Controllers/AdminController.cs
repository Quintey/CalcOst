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
using Newtonsoft.Json;

namespace Truboprovod_V2.Controllers
{
    public class AdminController : Controller
    {


        ApplicationDbContext db = new ApplicationDbContext();


        [Authorize(Roles = "admin")]
        public ActionResult Administr()
        {

            return  View();
        }

        [HttpPost]
        public void Edit(ApplicationDbContext dbContext)
        {
            // действия по редактированию
        }

        [HttpPost]
        public void Create(ApplicationDbContext dbContext)
        {
            // действия по добавлению
        }
        [HttpPost]
        public void Delete(int id)
        {
            // действия по удалению
        }


        public string GetData()
        {
           

            return JsonConvert.SerializeObject(db.Users.ToList());
        }
       
        
    }
}