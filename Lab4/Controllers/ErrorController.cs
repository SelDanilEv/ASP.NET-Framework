using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            ViewBag.url = Request.Url.AbsoluteUri.Split(';').Last();
            ViewBag.method = Request.HttpMethod;
            return View();
        }

        public ActionResult Internal()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}