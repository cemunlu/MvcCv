using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        GenericRepository<TblCertificates> repo = new GenericRepository<TblCertificates>();
        public ActionResult Index()
        {
            var cert = repo.List();
            return View(cert);
        }
        [HttpGet]
        public ActionResult CGet(int id)
        {
            var cert = repo.Find(x => x.ID == id);
            return View(cert);
        }
        [HttpPost]
        public ActionResult CGet(TblCertificates p)
        {
            var cert = repo.Find(x => x.ID == p.ID);
            cert.Certificate = p.Certificate;
            cert.Date = p.Date;
            repo.TUpdate(cert);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CAdd(TblCertificates p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CDelete(int id)
        {
            var cert = repo.Find(x => x.ID == id);
            repo.TDelete(cert);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CACDelete(TblCertificates p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
    }
}