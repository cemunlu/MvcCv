using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var admin = repo.List();
            return View(admin);
        }

        [HttpGet]
        public ActionResult AAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AAdd(TblAdmin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ADelete(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AEdit(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AEdit(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.UserName = p.UserName;
            t.Password = p.Password;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}