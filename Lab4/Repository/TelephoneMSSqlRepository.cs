﻿using Lab4.Models.BasicModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Repository
{
    public class TelephoneMSSqlRepository : ITelephoneRepository
    {
        public async Task<List<TelephoneNote>> GetTelephoneNotes()
        {
            var noteList = new List<TelephoneNote>();

            using (var db = new ApplicationContext())
            {
                noteList = await db.TelephoneNotes.ToListAsync();
            }

            return noteList;
        }

        public async Task AddTelephoneNote(TelephoneNote telephoneNote)
        {
            using (var db = new ApplicationContext())
            {
                db.TelephoneNotes.Add(telephoneNote);
                await db.SaveChangesAsync();
            }
        }

        public async Task RemoveTelephoneNote(TelephoneNote telephoneNote)
        {
            using (var db = new ApplicationContext())
            {
                db.TelephoneNotes.Remove(db.TelephoneNotes.Find(telephoneNote.Id));
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateTelephoneNote(TelephoneNote telephoneNote)
        {
            using (var db = new ApplicationContext())
            {
                var updatedNote = db.TelephoneNotes.FirstOrDefault(x => x.Id == telephoneNote.Id);

                updatedNote.Name = telephoneNote.Name;
                updatedNote.Phone = telephoneNote.Phone;

                await db.SaveChangesAsync();
            }
        }
    }
}
