using System.Web.Mvc;
using Pubtracker2MVC.Models;

namespace Pubtracker2MVC.Controllers
{
    public class TypesController : Controller
    {
        // GET: Types
        public ActionResult Index()
        {
            return View(Pubtracker2MVC.ptHelper.GetAll<ptType>("types"));
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
            if (Pubtracker2MVC.ptHelper.Create<ptType>("types", Type))
            { return RedirectToAction("Index"); }
            else
            { return View(Type); }
        }

        // GET: Types/Edit/5
        public ActionResult Edit(string id)
        {
            return View(Pubtracker2MVC.ptHelper.GetOne<ptType>("types", id));
        }

        // POST: Types/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, [Bind(Include = "TypeId,TypeName,Active")] ptType Type)
        {
            if (Pubtracker2MVC.ptHelper.Edit<ptType>(id, "types", Type))
            { return RedirectToAction("Index"); }
            else
            { return View(Type); }
        }


        // GET: Types/Delete/5
        public ActionResult Delete(string id)
        {
            return View(Pubtracker2MVC.ptHelper.GetOne<ptType>("types", id));
        }

        // POST: Types/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (Pubtracker2MVC.ptHelper.DeleteOne<ptType>("types", id))
            { return RedirectToAction("Index"); }
            else
            { return View(); }
        }//End Delete

    }
}
