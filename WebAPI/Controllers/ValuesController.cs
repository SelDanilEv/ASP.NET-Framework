using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        public class GGG
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
        }

        // POST api/values
        public void Post([FromBody] TelephoneNote value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] TelephoneNote value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
