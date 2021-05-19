using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TelephoneNote
    {
        public TelephoneNote()
        {
        }

        public TelephoneNote(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Phone")]
        public string Phone { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

    }
}
