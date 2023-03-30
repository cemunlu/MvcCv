using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCvEntities2 db = new DbCvEntities2();
        public ActionResult Index()
        {
            var results = db.TblAboutt.ToList();
            return View(results);
        }
        public PartialViewResult SocialMedia()
        {
            var socialMedia = db.TblSocialMedia.Where(x => x.Status == true).ToList();
            return PartialView(socialMedia);
        }
        public PartialViewResult Experience()
        {
            var experiences = db.TblExperience.ToList();
            return PartialView(experiences);
        }
        public PartialViewResult Education()
        {
            var educations = db.TblEducation.ToList();
            return PartialView(educations);
        }
        public PartialViewResult Skills()
        {
            var skills = db.TblSkills.ToList();
            return PartialView(skills);
        }
        public PartialViewResult Interests()
        {
            var interests = db.TblInterests.ToList();
            return PartialView(interests);
        }
        public PartialViewResult Certificates()
        {
            var certificate = db.TblCertificates.ToList();
            return PartialView(certificate);
        }
        [HttpGet] // sayfa yüklenince bu kısım çalışacak
        public PartialViewResult Communication()
        {
            
            return PartialView();
        }
        [HttpPost] // bir butona bastığımda dinamik oldugunda bu kısım çalışacak
        public PartialViewResult Communication(TblCommunication t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToLongDateString());
            db.TblCommunication.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}