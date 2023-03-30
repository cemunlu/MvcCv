using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SkillController : Controller
    {
        GenericRepository<TblSkills> repo = new GenericRepository<TblSkills>();
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }

        [HttpGet]
        public ActionResult NewSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSkill(TblSkills p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SDeleted(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            repo.TDelete(skill);
            return RedirectToAction("Index");
        }

        public ActionResult SEdit(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            return View(skill);
        }
    }
}