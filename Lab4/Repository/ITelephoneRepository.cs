namespace Lab4.Repository
{
    using Infrastructure;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITelephoneRepository
    {
        Task<List<TelephoneNote>> GetTelephoneNotes();

        Task AddTelephoneNote(TelephoneNote telephoneNote);

        Task RemoveTelephoneNote(TelephoneNote telephoneNote);

        Task UpdateTelephoneNote(TelephoneNote telephoneNote);
    }
}
