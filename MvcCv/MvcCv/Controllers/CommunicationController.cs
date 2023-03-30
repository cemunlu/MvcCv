using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CommunicationController : Controller
    {
        GenericRepository<TblCommunication> repo = new GenericRepository<TblCommunication>();
        public ActionResult Index()
        {
            var message = repo.List();
            return View(message);
        }
    }
}