namespace WebAPI.Controllers
{
    using WebAPI.Repository;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Hosting;
    using System.IO;
    using WebAPI.Models;

    public class DictController : ApiController
    {
        private ITelephoneRepository telephoneRepository;

        public DictController()
        {
            telephoneRepository = new TelephoneJSONRepository();
        }

        public DictController(ITelephoneRepository telephoneRepository)
        {
            this.telephoneRepository = telephoneRepository;
        }

        [HttpGet]
        public IList<TelephoneNote> GetAll()
        {
            List<TelephoneNote> result = null;

            try
            {
                result = telephoneRepository.GetTelephoneNotes().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }

        [HttpPost]
        public void Create([FromBody] TelephoneNote telephoneNote)
        {
            var x = Request;
            telephoneRepository.AddTelephoneNote(telephoneNote);
        }

        [HttpPut]
        public void Update([FromBody] TelephoneNote telephoneNote)
        {
            telephoneRepository.UpdateTelephoneNote(telephoneNote);
        }

        [HttpDelete]
        public void Delete([FromBody] TelephoneNote telephoneNote)
        {
            telephoneNote = (telephoneRepository.GetTelephoneNotes().GetAwaiter().GetResult()).FindLast(x => x.Name == telephoneNote.Name);
            telephoneRepository.RemoveTelephoneNote(telephoneNote);
        }
    }
}
