using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test2.context;
using test2.Models;

namespace test2.Controllers
{
    public class HomeController : Controller
    {
        test1Entities dbobj = new test1Entities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(empolyee clobj)
        {
            testtable tbobj = new testtable();

            tbobj.name = clobj.name;
            tbobj.email = clobj.email;
            tbobj.father_name = clobj.father_name;
            tbobj.address = clobj.address;
            if (clobj.id == 0)
            {
                dbobj.testtables.Add(tbobj);
                dbobj.SaveChanges();
            }
            else
            {
                dbobj.Entry(tbobj).State = System.Data.Entity.EntityState.Modified;
                dbobj.SaveChanges();


            }
           

            return View();
        }


        public ActionResult show()
        {
            var sh = dbobj.testtables.ToList();
            return View(sh);
        }



        public ActionResult delete(int id)
        {
            var del = dbobj.testtables.Where(m => m.id == id).First();
            dbobj.testtables.Remove(del);
            dbobj.SaveChanges();
            return RedirectToAction("show");
        }


        public ActionResult edit(int id)
        {
            empolyee clobj = new empolyee();
            var ed = dbobj.testtables.Where(m => m.id == id).First();
            clobj.id = ed.id;
            clobj.name = ed.name;
            clobj.email = ed.email;
            clobj.father_name = ed.father_name;
            clobj.address = ed.address;


            return View("Index",clobj);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}