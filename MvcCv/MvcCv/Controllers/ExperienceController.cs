using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var results = repo.List();
            return View(results);
        }
        [HttpGet]
        public ActionResult EAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EAdd(TblExperience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EDelete(int id)
        {
            TblExperience t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EGet(int id)
        {
            TblExperience t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EGet(TblExperience p)
        {
            TblExperience t = repo.Find(x => x.ID == p.ID);
            t.Title= p.Title;
            t.Subtitle= p.Subtitle;
            t.Date= p.Date;
            t.Explanation= p.Explanation;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}