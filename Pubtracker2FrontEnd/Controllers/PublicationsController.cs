using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pubtracker2FrontEnd.Models;

namespace Pubtracker2FrontEnd.Controllers
{
    public class PublicationsController : Controller
    {
        // GET: Publications
        public ActionResult Index()
        { return View(Pubtracker2FrontEnd.ptHelper.GetAll<ptPublication>("publications")); }

        // GET: Publications/Details/5
        public ActionResult Details(string id)
        { return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptPublication>("publications", id)); }

        // GET: Publications/Create
        public ActionResult Create()
        { return View(); }

        // POST: Publications/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "PublicationId,Title,TypeId,TypeName,Series,DivisionId,DivisionName,Remarks")] ptPublication publication)
        {
            if (Pubtracker2FrontEnd.ptHelper.Create<ptPublication>("publications", publication))
            { return RedirectToAction("Index"); }
            else
            { return View(publication); }
        }

        // GET: Publications/Edit/5
        public ActionResult Edit(string id)
        { return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptPublication>("publications", id)); }

        // POST: Publications/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, [Bind(Include = "PublicationId,Title,TypeId,TypeName,Series,DivisionId,DivisionName,Remarks")] ptPublication publication)
        {
            if (Pubtracker2FrontEnd.ptHelper.Edit<ptPublication>(id, "publications", publication))
            { return RedirectToAction("Index"); }
            else
            { return View(publication); }
        }

        // GET: Publications/Delete/5
        public ActionResult Delete(string id)
        { return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptPublication>("publications", id)); }

        // POST: Publications/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (Pubtracker2FrontEnd.ptHelper.DeleteOne<ptPublication>("publications", id))
            { return RedirectToAction("Index"); }
            else
            { return View(); }
        }

        // GET: Publications/CreateRole
        public ActionResult CreateRole(string pubid)
        { return View(); }

        // POST: Publications/CreateRole
        [HttpPost]
        public ActionResult CreateRole(string pubid, FormCollection collection)
        {
            //if (Pubtracker2FrontEnd.ptHelper.Create<ptPublication>("publications", publication))
            //{ return RedirectToAction("Index"); }
            //else
            //{ return View(publication); }
            return View();
        }
        // GET: Publications/EditRole
        public ActionResult EditRole(string pubid, string roleid)
        { /*return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptPublication>("publications", id));*/
            return View();
        }

        // POST: Publications/EditRole
        [HttpPost]
        public ActionResult EditRole(string pubid, string roleid, FormCollection collection)
        {
            //if (Pubtracker2FrontEnd.ptHelper.Edit<ptPublication>(id, "publications", publication))
            //{ return RedirectToAction("Index"); }
            //else
            //{ return View(publication); }
            return View();
        }

        // GET: Publications/DeleteRole
        public ActionResult DeleteRole(string pubid, string roleid)
        {/* return View(Pubtracker2FrontEnd.ptHelper.GetOne<ptPublication>("publications", id));*/
            return View();
        }

        // POST: Publications/DeleteRole
        [HttpPost]
        public ActionResult DeleteRole(string pubid, string roleid, FormCollection collection)
        {
            //if (Pubtracker2FrontEnd.ptHelper.DeleteOne<ptPublication>("publications", id))
            //{ return RedirectToAction("Index"); }
            //else
            //{ return View(); }
            return View();
        }

    }//end class
}//end namespace
