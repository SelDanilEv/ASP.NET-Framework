using Lab4.Models;
using Lab4.Models.BasicModels;
using Lab4.Repository;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class DictController : Controller
    {
        private static ITelephoneRepository repository = new TelephoneJSONRepository();

        public ActionResult ChangeSource()
        {
            if (repository is TelephoneMSSqlRepository)
            {
                repository = new TelephoneJSONRepository();
            }
            else
            {
                repository = new TelephoneMSSqlRepository();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Index()
        {
            if (repository is TelephoneMSSqlRepository)
            {
                ViewBag.CurrentSource = "MS SQL Server";
            }
            else
            {
                ViewBag.CurrentSource = "JSON FILE";
            }

            return View(await repository.GetTelephoneNotes());
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
                await repository.AddTelephoneNote(telephoneNote);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Update(int id)
        {
            return View((await repository.GetTelephoneNotes()).FindLast(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(TelephoneNote telephoneNote)
        {
            try
            {
                await repository.UpdateTelephoneNote(telephoneNote);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            return View((await repository.GetTelephoneNotes()).FindLast(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(TelephoneNote telephoneNote)
        {
            try
            {
                await repository.RemoveTelephoneNote(telephoneNote);
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
