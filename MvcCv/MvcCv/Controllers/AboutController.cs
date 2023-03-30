using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<TblAboutt> repo = new GenericRepository<TblAboutt>();
        [HttpGet]
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }
        [HttpPost]
        public ActionResult Index(TblAboutt p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Name = p.Name;
            t.LastName = p.LastName;
            t.Explanation = p.Explanation;
            t.Addres = p.Addres;
            t.Mail = p.Mail;
            t.Phone= p.Phone;
            t.Photog = p.Photog;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}