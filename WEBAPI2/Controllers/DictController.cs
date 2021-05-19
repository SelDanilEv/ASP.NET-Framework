using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using WEBAPI2.Models;

namespace WEBAPI2.Controllers
{
    public class DictController : ApiController
    {
        private static string file = HostingEnvironment.MapPath("~/App_Data/database.json");
        static public List<TelephoneNote> Contacts { get; set; }

        [HttpPost]
        public TelephoneNote Add([FromBody] TelephoneNote item)
        {
            Contacts.Add(new TelephoneNote { Name = item.Name, Phone = item.Phone });

            string json = JsonConvert.SerializeObject(Contacts);
            File.WriteAllText(file, json);

            return item;
        }

        public TelephoneNote Get(string name) => Contacts.Find(c => c.Name == name);

        [HttpGet]
        public IEnumerable<TelephoneNote> GetAll()
        {
            string jsonString = File.ReadAllText(file);
            Contacts = JsonConvert.DeserializeObject<List<TelephoneNote>>(jsonString).ToList();

            return Contacts.OrderBy(c => c.Name).ToList();
        }

        [HttpDelete]
        public void Remove([FromBody] string name)
        {
            Contacts.Remove(Get(name));

            string json = JsonConvert.SerializeObject(Contacts);
            File.WriteAllText(file, json);
        }

        [HttpPut]
        public void Update([FromBody] TelephoneNote item)
        {
            TelephoneNote newContact = Get(item.Name);
            newContact.Phone = item.Phone;

            string json = JsonConvert.SerializeObject(Contacts);
            File.WriteAllText(file, json);
        }
    }

}