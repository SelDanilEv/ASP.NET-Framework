namespace Lab4.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Defender SD Lab (2021)";

            return View();
        }
    }
}