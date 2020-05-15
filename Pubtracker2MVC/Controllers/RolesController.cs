using System.Web.Mvc;
using Pubtracker2MVC.Models;

namespace Pubtracker2MVC.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            return View(Pubtracker2MVC.ptHelper.GetAll<ptRole>("roles"));
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
            if (Pubtracker2MVC.ptHelper.Create<ptRole>("roles", Role))
            { return RedirectToAction("Index"); }
            else
            { return View(Role); }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            return View(Pubtracker2MVC.ptHelper.GetOne<ptRole>("roles", id));
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, [Bind(Include = "RoleId,RoleName,Active")] ptRole Role)
        {
            if (Pubtracker2MVC.ptHelper.Edit<ptRole>(id, "roles", Role))
            { return RedirectToAction("Index"); }
            else
            { return View(Role); }
        }


        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            return View(Pubtracker2MVC.ptHelper.GetOne<ptRole>("roles", id));
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (Pubtracker2MVC.ptHelper.DeleteOne<ptRole>("roles", id))
            { return RedirectToAction("Index"); }
            else
            { return View(); }
        }//End Delete

    }
}
