namespace Lab4.Controllers
{
    using Lab4.Models;
    using Lab4.Repository;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Infrastructure;

    public class DictController : Controller
    {
        private ITelephoneRepository telephoneRepository;

        public DictController(ITelephoneRepository telephoneRepository)
        {
            this.telephoneRepository = telephoneRepository;
        }


        public ActionResult ChangeSource()
        {
            //if (repository is TelephoneMSSqlRepository)
            //{
            //    repository = new TelephoneJSONRepository();
            //}
            //else
            //{
            //    repository = new TelephoneMSSqlRepository();
            //}

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Index()
        {
            if (telephoneRepository is TelephoneMSSqlRepository)
            {
                ViewBag.CurrentSource = "MS SQL Server";
            }
            else
            {
                ViewBag.CurrentSource = "JSON FILE";
            }
            List<TelephoneNote> result = null;

            try
            {
                result = await telephoneRepository.GetTelephoneNotes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TelephoneNote telephoneNote)
        {
            try
            {
                await telephoneRepository.AddTelephoneNote(telephoneNote);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Update(string name)
        {
            return View((await telephoneRepository.GetTelephoneNotes()).FindLast(x => x.Name == name));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(TelephoneNote telephoneNote)
        {
            try
            {
                await telephoneRepository.UpdateTelephoneNote(telephoneNote);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(string name)
        {
            return View((await telephoneRepository.GetTelephoneNotes()).FindLast(x => x.Name == name));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(TelephoneNote telephoneNote)
        {
            try
            {
                telephoneNote = (await telephoneRepository.GetTelephoneNotes()).FindLast(x => x.Name == telephoneNote.Name);
                await telephoneRepository.RemoveTelephoneNote(telephoneNote);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public ActionResult ProcessError404()
        {
            return View("Error404",new Error404Model() { });
        }
    }
}
