using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    [Serializable]
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

        public TelephoneNote(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }

        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Phone")]
        public string Phone { get; set; }
        [Key]
        public int Id { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

    }
}
