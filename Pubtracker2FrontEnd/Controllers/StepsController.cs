using System.Web.Mvc;
using Pubtracker2FrontEnd.Models;

namespace Pubtracker2FrontEnd.Controllers
{
    public class StepsController : Controller
    {
        // GET: Steps
        public ActionResult Index()
        {
            return View(Pubtracker2FrontEnd.ptHelper.GetAll<ptStep>("steps"));
        }

        // GET: Steps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Steps/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "StepId,StepName,Active")] ptStep Step)
        {
            if (Pubtracker2FrontEnd.ptHelper.Create<ptStep>("steps", Step))
            { return RedirectToAction("Index"); }
            else
            { return View(Step); }
        }

        // GET: Steps/Edit/5
        public ActionResult Edit(string id)
        {
            return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptStep>("steps", id));
        }

        // POST: Steps/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, [Bind(Include = "StepId,StepName,Active")] ptStep Step)
        {
            if (Pubtracker2FrontEnd.ptHelper.Edit<ptStep>(id, "steps", Step))
            { return RedirectToAction("Index"); }
            else
            { return View(Step); }
        }


        // GET: Steps/Delete/5
        public ActionResult Delete(string id)
        {
            return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptStep>("steps", id));
        }

        // POST: Steps/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (Pubtracker2FrontEnd.ptHelper.DeleteOne<ptStep>("steps", id))
            { return RedirectToAction("Index"); }
            else
            { return View(); }
        }//End Delete

    }
}
