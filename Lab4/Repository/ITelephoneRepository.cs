using Lab4.Models.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Repository
{
    interface ITelephoneRepository
    {
        Task<List<TelephoneNote>> GetTelephoneNotes();

        Task AddTelephoneNote(TelephoneNote telephoneNote);

        Task RemoveTelephoneNote(TelephoneNote telephoneNote);

        Task UpdateTelephoneNote(TelephoneNote telephoneNote);
    }
}
