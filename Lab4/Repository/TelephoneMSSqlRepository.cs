namespace Lab4.Repository
{
    using Infrastructure;
    using Lab6_EntityLibrary;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TelephoneMSSqlRepository : ITelephoneRepository
    {
        private TelephoneManager _telephoneManager;
        public TelephoneMSSqlRepository()
        {
            _telephoneManager = new TelephoneManager();
        }

        public async Task<List<TelephoneNote>> GetTelephoneNotes()
        {
            var noteList = await _telephoneManager.GetTelephoneNotes();

            return noteList;
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
            await _telephoneManager.UpdateTelephoneNote(telephoneNote);
        }
    }
}
