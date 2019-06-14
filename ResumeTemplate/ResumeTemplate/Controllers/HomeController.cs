using ResumeTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeTemplate.Controllers
{
    public class HomeController : Controller
    {
        UniqueResumeEntities db = new UniqueResumeEntities();


        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.Educations = db.Educations.ToList();
            model.Experiences = db.Experiences.ToList();

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