using System.Web.Mvc;
using Pubtracker2FrontEnd.Models;

namespace Pubtracker2FrontEnd.Controllers
{
    public class DivisionsController : Controller
    {
        // GET: Divisions
        public ActionResult Index()
        {
            return View(Pubtracker2FrontEnd.ptHelper.GetAll<ptDivision>("divisions"));
        }

        // GET: Divisions/Create
        public ActionResult Create()
        {
            return View(new ptDivision());
        }

        // POST: Divisions/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "DivisionId,DivisionName,Active")] ptDivision division)
        {
            if (Pubtracker2FrontEnd.ptHelper.Create<ptDivision>("divisions", division))
            { return RedirectToAction("Index"); }
            else
            { return View(division); }
        }

        // GET: Divisions/Edit/5
        public ActionResult Edit(string id)
        {
            return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptDivision>("divisions",id));
        }

        // POST: Divisions/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, [Bind(Include = "DivisionId,DivisionName,Active")] ptDivision division)
        {
            if (Pubtracker2FrontEnd.ptHelper.Edit<ptDivision>(id,"divisions",division))
            { return RedirectToAction("Index"); }
            else
            { return View(division); }
        }

        // GET: Divisions/Delete/5
        public ActionResult Delete(string id)
        {
            return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptDivision>("divisions", id));
        }

        // POST: Divisions/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (Pubtracker2FrontEnd.ptHelper.DeleteOne<ptDivision>("divisions", id))
            { return RedirectToAction("Index"); }
            else
            { return View(); }
        }//End Delete

    }// End Class
}//End namespace

