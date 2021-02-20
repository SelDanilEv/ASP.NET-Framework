using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    public class HttpHandler_1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var aaa = context.Request.Params.Get("ParmA");
            var bbb = context.Request.Params.Get("ParmB");
            var XYZ = context.Request.FilePath.Split('.').LastOrDefault();
            var method = context.Request.HttpMethod;
            var responseTxt = String.Empty;
            switch (method.ToUpper())
            {
                case "GET":
                    responseTxt = $"GET - Http - {XYZ}:ParmA = {aaa}, ParmB = {bbb}";
                    break;
                case "POST":
                    responseTxt = $"POST - Http - {XYZ}:ParmA = {aaa}, ParmB = {bbb}";
                    break;
                case "PUT":
                    responseTxt = $"PUT - Http - {XYZ}:ParmA = {aaa}, ParmB = {bbb}";
                    break;
            }
            context.Response.Write(responseTxt);
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
}