using ResumeTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeTemplate.Controllers
{
    public class EducationController : Controller
    {
        UniqueResumeEntities db = new UniqueResumeEntities();
        // GET: Education
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Education education)
        {
            db.Educations.Add(education);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}