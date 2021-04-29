using System.IO;
using System.Web.Mvc;

namespace Lab5a.Controllers
{
    public class CResearchController : Controller
    {
        [AcceptVerbs("post", "get")]
        public string C01()
        {
            string result = $"{$"--Method: {Request.HttpMethod}\n"}{$"--Uri: {Request.Url.AbsoluteUri}\n"}{$"--Headers: {Request.Headers}\n"}{$"--QueryString: {Request.QueryString}\n"}";

            if(Request.HttpMethod == "POST")
            {
                using (StreamReader reader = new StreamReader(Request.InputStream))
                {
                    result += $"Body: {reader.ReadToEnd()}\n";
                }
            }

            return result;
        }

        [AcceptVerbs("post", "get")]
        public string C02()
        {
            string body;
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                body = $"{reader.ReadToEnd()}\n";
            }

            return $"--Status: {Response.StatusCode} {Response.StatusDescription}\n" +
                $"--Headers: {Response.Headers}\n" +
                $"Body: {body}";
        }
    }
}