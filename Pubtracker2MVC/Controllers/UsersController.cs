using System.Web.Mvc;
using Pubtracker2MVC.Models;

namespace Pubtracker2MVC.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View(Pubtracker2MVC.ptHelper.GetAll<ptUser>("users"));
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "UserId,LastName,FirstName,Active")] ptUser User)
        {
            if (Pubtracker2MVC.ptHelper.Create<ptUser>("users", User))
            { return RedirectToAction("Index"); }
            else
            { return View(User); }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            return View(Pubtracker2MVC.ptHelper.GetOne<ptUser>("users", id));
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, [Bind(Include = "UserId,LastName,FirstName,Active")] ptUser User)
        {
            if (Pubtracker2MVC.ptHelper.Edit<ptUser>(id, "users", User))
            { return RedirectToAction("Index"); }
            else
            { return View(User); }
        }


        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            return View(Pubtracker2MVC.ptHelper.GetOne<ptUser>("users", id));
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (Pubtracker2MVC.ptHelper.DeleteOne<ptUser>("users", id))
            { return RedirectToAction("Index"); }
            else
            { return View(); }
        }//End Delete

    }
}
