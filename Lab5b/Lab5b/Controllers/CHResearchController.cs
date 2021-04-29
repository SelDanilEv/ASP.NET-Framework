using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;

namespace Lab5b.Controllers
{
    public class CHResearchController : Controller
    {
        static DateTime date = DateTime.Now;

        [HttpGet]
        [OutputCache(Location = OutputCacheLocation.Client, Duration = 20)]
        public ActionResult AD()
        {
            date = DateTime.Now;
            return Content($"{date}");
        }

        
        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.Any, Duration = 7, VaryByParam = "*")]
        public ActionResult AP()
        {
            var x = Request.QueryString.Get("x");
            var y = Request.QueryString.Get("y");

            Cache cache = new Cache();

            cache.Insert("1",(object)"2");

            date = DateTime.Now;
            return Content($"{date}: {x} - {y}");
        }
    }
}