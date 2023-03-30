using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<TblSocialMedia> repo = new GenericRepository<TblSocialMedia>();
        public ActionResult Index()
        {
            var socialMedia = repo.List();
            return View(socialMedia);
        }
        [HttpGet]
        public ActionResult SmAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SmAdd(TblSocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SmEdit(int id)
        {
            var sm = repo.Find(x => x.ID == id);
            return View(sm);
        }
        [HttpPost]
        public ActionResult SmEdit(TblSocialMedia p)
        {
            var sm = repo.Find(x => x.ID == p.ID);
            sm.Name = p.Name;
            sm.Icon = p.Icon;
            sm.Link = p.Link;
            sm.Status = true;
            repo.TUpdate(sm);
            return RedirectToAction("Index");
        }

        public ActionResult SmDelete(int id)
        {
            var sm = repo.Find(x => x.ID == id);
            sm.Status = false;
            repo.TUpdate(sm);
            return RedirectToAction("Index");
        }
    }
}