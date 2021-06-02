using Infrastructure;
using System;
using System.Collections.Generic;
using WCF.Repository;

namespace WCF
{
    public class TelephoneBookService : IService
    {
        private ITelephoneRepository telephoneRepository = new TelephoneJSONRepository();

        public void Add(TelephoneNote telephoneNote)
        {
            telephoneRepository.AddTelephoneNote(telephoneNote).GetAwaiter().GetResult();
        }

        public void Delete(TelephoneNote telephoneNote)
        {
            telephoneRepository.RemoveTelephoneNote(telephoneNote).GetAwaiter().GetResult();
        }

        public List<TelephoneNote> GetAll()
        {
            return telephoneRepository.GetTelephoneNotes().GetAwaiter().GetResult();
        }

        public void Update(TelephoneNote telephoneNote)
        {
            telephoneRepository.UpdateTelephoneNote(telephoneNote);
        }
    }
}
