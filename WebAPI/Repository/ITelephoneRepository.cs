namespace WebAPI.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebAPI.Models;

    public interface ITelephoneRepository
    {
        Task<List<TelephoneNote>> GetTelephoneNotes();

        Task AddTelephoneNote(TelephoneNote telephoneNote);

        Task RemoveTelephoneNote(TelephoneNote telephoneNote);

        Task UpdateTelephoneNote(TelephoneNote telephoneNote);
    }
}
