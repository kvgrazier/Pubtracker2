using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
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
        {
            return View(Pubtracker2FrontEnd.ptHelper.BlankPubVM()); 
        }

        // POST: Publications/Create
        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.BlankPubVM();
            p.vmPublication.PublicationId = fc["vmPublication.PublicationId"].ToString();
            p.vmPublication.Title = fc["vmPublication.Title"];
            string typeValue = fc["Type"];
            p.vmPublication.Series = fc["vmPublication.Series"].ToString();
            string divisionValue = fc["Division"];
            p.vmPublication.Remarks = fc["vmPublication.Remarks"].ToString();
            string typeText = p.slType.ToList().Find(x => x.Value == typeValue).Text;
            string divisionText = p.slDivision.ToList().Find(x => x.Value == divisionValue).Text;
            TypeViewModel type = new TypeViewModel();
            type.TypeId = typeValue;
            type.TypeName = typeText;
            p.vmPublication.Type = type;
            DivisionViewModel division = new DivisionViewModel();
            division.DivisionId = divisionValue;
            division.DivisionName = divisionText;
            p.vmPublication.Division = division;
            ptRoles pr = new ptRoles();
            pr.RoleId = "Contact";
            pr.RoleName = "Contact";
            pr.UserId = "None Assigned";
            p.vmPublication.Roles = new List<ptRoles>();
            p.vmPublication.Roles.Add(pr);
            ptStatus status = new ptStatus();
            status.StepId = "Define";
            status.StepName = "Define";
            status.StepDateTime = DateTime.Now;
            p.vmPublication.Statuses  = new List<ptStatus>();
            p.vmPublication.Statuses.Add(status);
            if (Pubtracker2FrontEnd.ptHelper.Create<ptPublication>("publications", p.vmPublication))
            { return RedirectToAction("Index"); }
            else
            { return View(p); }
        }

        // GET: Publications/Edit/5
        public ActionResult Edit(string id)
        { return View(Pubtracker2FrontEnd.ptHelper.EditPubVM(id)); }

        // POST: Publications/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection fc)
        {
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(id);
            p.vmPublication.PublicationId = fc["vmPublication.PublicationId"].ToString();
            p.vmPublication.Title = fc["vmPublication.Title"];
            string typeValue = fc["Type"];
            p.vmPublication.Series = fc["vmPublication.Series"].ToString();
            string divisionValue = fc["Division"];
            p.vmPublication.Remarks = fc["vmPublication.Remarks"].ToString();
            string typeText = p.slType.ToList().Find(x => x.Value == typeValue).Text;
            string divisionText = p.slDivision.ToList().Find(x => x.Value == divisionValue).Text;
            TypeViewModel type = new TypeViewModel();
            type.TypeId = typeValue;
            type.TypeName = typeText;
            p.vmPublication.Type = type;
            DivisionViewModel division = new DivisionViewModel();
            division.DivisionId = divisionValue;
            division.DivisionName = divisionText;
            p.vmPublication.Division = division;
            //ptRoles pr = new ptRoles();
            //pr.RoleId = "Contact";
            //pr.RoleName = "Contact";
            //pr.UserId = "None Assigned";
            //p.vmPublication.Roles = new List<ptRoles>();
            //p.vmPublication.Roles.Add(pr);
            //ptStatus status = new ptStatus();
            //status.StepId = "Define";
            //status.StepName = "Define";
            //status.StepDateTime = DateTime.Now;
            //p.vmPublication.Statuses = new List<ptStatus>();
            //p.vmPublication.Statuses.Add(status);
            if (Pubtracker2FrontEnd.ptHelper.Edit<ptPublication>(id, "publications", p.vmPublication))
            { return RedirectToAction("Index"); }
            else
            { return View(p); }
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
        public ActionResult CreateRole(string pubid, FormCollection fc)
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
