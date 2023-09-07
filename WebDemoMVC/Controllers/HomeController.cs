using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemoMVC.EntitiesFrameWork;
using WebDemoMVC.Models;

namespace WebDemoMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string name)
        {
            var model = new List<StudentModels>();

            var dbContext = new StudentDbContext();
            // dbContext.SaveChanges();
            //dbContext.student.Add(new EntitiesFrameWork.Entites.Student { Id = 10, Name = "abc_def10" });
           // dbContext.student.Add(new EntitiesFrameWork.Entites.Student { Id = 11, Name = "abc_def11" });
           // dbContext.student.Add(new EntitiesFrameWork.Entites.Student { Id = 12, Name = "abc_def12" });




            var list_student = dbContext.student.ToList();
            if (list_student.Count > 0)
            {
                for (int i = 0; i < list_student.Count; i++)
                {
                    var item = list_student[i];
                    model.Add(new StudentModels { Id = item.Id, Name = item.Name });
                }
            }


            return View(model);
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