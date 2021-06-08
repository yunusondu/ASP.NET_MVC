using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using firstproject.Entity;

namespace firstproject.Controllers
{
    public class kategoriController : Controller
    {
        // GET: kategori
        public ActionResult Index()
        {
            return View();
        }
    }
}