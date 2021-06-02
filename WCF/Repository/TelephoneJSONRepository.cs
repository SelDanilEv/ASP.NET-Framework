namespace WCF.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lab6_JSONLibrary;
    using Infrastructure;
    using System.Reflection;
    using System.IO;

    public class TelephoneJSONRepository : ITelephoneRepository
    {
        private static TelephoneManager<TelephoneNote> _telephoneManager =
            new TelephoneManager<TelephoneNote>(Directory.GetCurrentDirectory() + "\\database.json");

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
