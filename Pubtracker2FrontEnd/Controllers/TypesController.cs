using System.Web.Mvc;
using Pubtracker2FrontEnd.Models;

namespace Pubtracker2FrontEnd.Controllers
{
    public class TypesController : Controller
    {
        // GET: Types
        public ActionResult Index()
        {
            return View(Pubtracker2FrontEnd.ptHelper.GetAll<ptType>("types"));
        }

        // GET: Types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Types/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "TypeId,TypeName,Active")] ptType Type)
        {
            if (Pubtracker2FrontEnd.ptHelper.Create<ptType>("types", Type))
            { return RedirectToAction("Index"); }
            else
            { return View(Type); }
        }

        // GET: Types/Edit/5
        public ActionResult Edit(string id)
        {
            return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptType>("types", id));
        }

        // POST: Types/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, [Bind(Include = "TypeId,TypeName,Active")] ptType Type)
        {
            if (Pubtracker2FrontEnd.ptHelper.Edit<ptType>(id, "types", Type))
            { return RedirectToAction("Index"); }
            else
            { return View(Type); }
        }


        // GET: Types/Delete/5
        public ActionResult Delete(string id)
        {
            return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptType>("types", id));
        }

        // POST: Types/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (Pubtracker2FrontEnd.ptHelper.DeleteOne<ptType>("types", id))
            { return RedirectToAction("Index"); }
            else
            { return View(); }
        }//End Delete

    }
}
