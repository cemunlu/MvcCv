using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {
        GenericRepository<TblEducation> repo = new GenericRepository<TblEducation>();
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }
        [HttpGet]
        public ActionResult EdAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EdAdd(TblEducation p)
        {
            if (!ModelState.IsValid)
            {
                return View("EdAdd");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EdDelete(int id)
        {
            var ed = repo.Find(x => x.ID == id);
            repo.TDelete(ed);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EdEdit(int id)
        {
            var ed = repo.Find(x => x.ID == id);
            return View(ed);
        }
        [HttpPost]
        public ActionResult EdEdit(TblEducation p)
        {
            if (!ModelState.IsValid)
            {
                return View("EdEdit");
            }
            var ed = repo.Find(x => x.ID == p.ID);
            ed.Title = p.Title;
            ed.Subtitle1 = p.Subtitle1;
            ed.Subtitle2 = p.Subtitle2;
            ed.Date = p.Date;
            ed.GradeAverage= p.GradeAverage;
            repo.TUpdate(ed);
            return RedirectToAction("Index");
        }
    }
}