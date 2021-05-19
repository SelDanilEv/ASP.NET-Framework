using Lab6_JSONLibrary;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace ASMX.Models
{
    public class TelephoneJSONRepository
    {
        private static TelephoneManager<TelephoneNote> _telephoneManager =
            new TelephoneManager<TelephoneNote>(HostingEnvironment.MapPath("~/database.json"));

        public async Task<List<TelephoneNote>> GetTelephoneNotes()
        {
            var result = await _telephoneManager.GetTelephoneNotes();

            return result;
        }

        public async Task AddTelephoneNote(TelephoneNote telephoneNote)
        {
            await _telephoneManager.AddTelephoneNote(telephoneNote);
        }

        public async Task RemoveTelephoneNote(TelephoneNote telephoneNote)
        {
            await _telephoneManager.RemoveTelephoneNote(telephoneNote);
        }

        public async Task UpdateTelephoneNote(TelephoneNote telephoneNote)
        {
            await RemoveTelephoneNote(telephoneNote);
            await AddTelephoneNote(telephoneNote);
        }
    }
}