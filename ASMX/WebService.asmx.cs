using ASMX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ASMX
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        Models.TelephoneJSONRepository telephoneRepository = new TelephoneJSONRepository();

        [WebMethod(Description = "Get all nodes", EnableSession = true)]
        public List<TelephoneNote> GetDict()
        {
            return telephoneRepository.GetTelephoneNotes().GetAwaiter().GetResult();
        }

        [WebMethod(Description = "Add new node", EnableSession = true)]
        public string AddDict(string name, string phone)
        {
            var note = new TelephoneNote(name, phone);
            telephoneRepository.AddTelephoneNote(note).GetAwaiter();

            return "OK";
        }

        [WebMethod(Description = "Update number by name", EnableSession = true)]
        public string UpdDict(string name, string phone)
        {
            var note = new TelephoneNote(name, phone);
            telephoneRepository.UpdateTelephoneNote(note).GetAwaiter();

            return "OK";
        }

        [WebMethod(Description = "Delete number by name", EnableSession = true)]
        public string DelDict(string name)
        {
            var note = new TelephoneNote() { Name = name };
            telephoneRepository.RemoveTelephoneNote(note).GetAwaiter();

            return "OK";
        }
    }
}
