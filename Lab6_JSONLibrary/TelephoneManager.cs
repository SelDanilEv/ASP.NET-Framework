namespace Lab6_JSONLibrary
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using System.Text.Json;
    using System;

    public class TelephoneManager<T> where T : class
    {
        private static string _path = "database.json";
        public TelephoneManager(string path)
        {
            _path = path;
        }
        public TelephoneManager()
        {
        }

        [Serializable]
        private class InternalT
        {
            public int Id { get; set; }
            public T Item { get; set; }
        }

        public async Task<List<T>> GetTelephoneNotes()
        {
            List<T> noteList = new List<T>();
            List<InternalT> internalTs;

            using (var fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                internalTs = await JsonSerializer.DeserializeAsync<List<InternalT>>(fs);
                fs.Close();
            }

            foreach (var item in internalTs)
            {
                noteList.Add(item.Item);
            }

            return noteList;
        }

        public async Task AddTelephoneNote(T item)
        {
            List<T> noteList;
            List<InternalT> internalTs = new List<InternalT>();
            try
            {
                noteList = await GetTelephoneNotes();
            }
            catch
            {
                noteList = new List<T>();
            }

            foreach (var i in noteList)
            {
                internalTs.Add(new InternalT() { Id = internalTs.Count, Item = i });
            }

            internalTs.Add(new InternalT() { Id = internalTs.Count, Item = item });

            using (var fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, internalTs);
                fs.Close();
            }
        }

        public async Task RemoveTelephoneNote(T item)
        {
            List<T> noteList = await GetTelephoneNotes();
            List<InternalT> internalTs = new List<InternalT>();


            noteList.RemoveAll(x => x.GetHashCode() == item.GetHashCode());

            foreach (var i in noteList)
            {
                internalTs.Add(new InternalT() { Id = internalTs.Count, Item = i });
            }

            using (var fs = new FileStream(_path, FileMode.Truncate))
            {
                await JsonSerializer.SerializeAsync(fs, internalTs);
                fs.Close();
            }
        }

        public async Task UpdateTelephoneNote(T telephoneNote)
        {
            await RemoveTelephoneNote(telephoneNote);
            await AddTelephoneNote(telephoneNote);
        }
    }
}
