using System.Web.Mvc;
using Pubtracker2FrontEnd.Models;

namespace Pubtracker2FrontEnd.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            return View(Pubtracker2FrontEnd.ptHelper.GetAll<ptRole>("roles"));
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "RoleId,RoleName,Active")] ptRole Role)
        {
            if (Pubtracker2FrontEnd.ptHelper.Create<ptRole>("roles", Role))
            { return RedirectToAction("Index"); }
            else
            { return View(Role); }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptRole>("roles", id));
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, [Bind(Include = "RoleId,RoleName,Active")] ptRole Role)
        {
            if (Pubtracker2FrontEnd.ptHelper.Edit<ptRole>(id, "roles", Role))
            { return RedirectToAction("Index"); }
            else
            { return View(Role); }
        }


        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptRole>("roles", id));
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (Pubtracker2FrontEnd.ptHelper.DeleteOne<ptRole>("roles", id))
            { return RedirectToAction("Index"); }
            else
            { return View(); }
        }//End Delete

    }
}
