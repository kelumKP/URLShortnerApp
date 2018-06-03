using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace URLShortnerWebApp.Controllers
{
    public class URLGeneratorController : Controller
    {
        // GET: URLGenerator
        public ActionResult Index()
        {
            return View();
        }
    }
}