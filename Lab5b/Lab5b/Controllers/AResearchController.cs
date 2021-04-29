using System;
using System.Web.Mvc;

namespace Lab5b.Controllers
{
    public class AResearchController : Controller
    {
        [AAAtribute]
        public ActionResult AA()
        {
            return Content("<p>AA</p>");
        }

        public class AAAtribute : FilterAttribute, IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<b>OnActionExecuted</b>");
            }

            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<b>OnActionExecuting</b>");
            }
        }


        [ARAtribute]
        public ActionResult AR()
        {
            return Content("<p>AR</p>");
        }

        public class ARAtribute : FilterAttribute, IResultFilter
        {
            public void OnResultExecuted(ResultExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<b>OnResultExecuted</b>");
            }

            public void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<b>OnResultExecuting</b>");
            }
        }

        [AEAtribute]
        public ActionResult AE()
        {
            throw new Exception("AE");
        }

        public class AEAtribute : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<b>OnException</b>");

                filterContext.ExceptionHandled = true;
            }
        }
    }
}