using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    public class HttpHandler_4 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var x = context.Request.Params.Get("x");
            var y = context.Request.Params.Get("y");
            var method = context.Request.HttpMethod;
            var responseTxt = String.Empty;
            switch (method.ToUpper())
            {
                case "GET":
                    context.Response.ContentType = "text/html";
                    context.Response.WriteFile("static/Task6.html");
                    break;
                case "POST":
                    responseTxt = $"{int.Parse(x) * int.Parse(y)}";
                    break;
            }
            context.Response.Write(responseTxt);
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
}