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
        { return View(Pubtracker2FrontEnd.ptHelper.BlankPubVM()); }

        // POST: Publications/Create
        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.BlankPubVM();
            p.vmPublication.PublicationId = fc["vmPublication.PublicationId"].ToString();
            p.vmPublication.SortId = Convert.ToInt32(fc["vmPublication.SortId"].ToString());
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
            p.vmPublication.SortId = Convert.ToInt32(fc["vmPublication.SortId"].ToString());
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
        public ActionResult CreateRole(string id)
        {
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(id);
            return View(p); 
        }

        // POST: Publications/CreateRole
        [HttpPost]
        public ActionResult CreateRole(FormCollection fc)
        {
            string id = fc["vmPublication.PublicationId"].ToString();
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(id);
            ptRoles pr = new ptRoles();
            pr.RoleId = fc["Role"];
            pr.RoleName = p.slRole.ToList().Find(x => x.Value == fc["Role"]).Text;
            pr.UserId = fc["User"];
            p.vmPublication.Roles.Add(pr);
            if (Pubtracker2FrontEnd.ptHelper.Edit<ptPublication>(id, "publications", p.vmPublication))
            { return RedirectToAction("Details/"+ id); }
            else
            { return View(p); }
        }//End Create Role

        // GET: Publications/EditRole
        public ActionResult EditRole(string pubid, string roleid)
        {
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(pubid);
            p.SelectedRoleId = roleid;
            p.SelectedUserId = p.vmPublication.Roles.Find(x => x.RoleId == roleid).UserId;
            return View(p);
        }

        // POST: Publications/EditRole
        [HttpPost]
        public ActionResult EditRole(FormCollection fc)
        {
            string id = fc["vmPublication.PublicationId"].ToString();
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(id);
            p.vmPublication.Roles.Find(x => x.RoleId == fc["RoleId"]).UserId = fc["User"];
            if (Pubtracker2FrontEnd.ptHelper.Edit<ptPublication>(id, "publications", p.vmPublication))
            { return RedirectToAction("Details/" + id); }
            else
            { return View(p); }
        }

        // GET: Publications/DeleteRole
        public ActionResult DeleteRole(string pubid, string roleid)
        {
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(pubid);
            p.SelectedRoleId = roleid;
            return View(p);
        }//End Delete Role

        // POST: Publications/DeleteRole
        [HttpPost]
        public ActionResult DeleteRole(FormCollection fc)
        {
            string id = fc["vmPublication.PublicationId"].ToString();
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(id);
            p.vmPublication.Roles.RemoveAll(x => x.RoleId == fc["RoleId"]);
            if (Pubtracker2FrontEnd.ptHelper.Edit<ptPublication>(id, "publications", p.vmPublication))
            { return RedirectToAction("Details/" + id); }
            else
            { return View(p); }
        }//End Delete Role

        // GET: Publications/CreateStatus
        public ActionResult CreateStatus(string id)
        {
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(id);
            return View(p);
        }//End Create Status

        // POST: Publications/CreateStatus
        [HttpPost]
        public ActionResult CreateStatus(FormCollection fc)
        {
            string id = fc["vmPublication.PublicationId"].ToString();
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(id);
            ptStatus pr = new ptStatus();
            pr.StepId = fc["Step"];
            pr.StepName = p.slStep.ToList().Find(x => x.Value == fc["Step"]).Text;
            pr.StepDateTime = Convert.ToDateTime(fc["StepDateTime"]);
            p.vmPublication.Statuses.Add(pr);
            if (Pubtracker2FrontEnd.ptHelper.Edit<ptPublication>(id, "publications", p.vmPublication))
            { return RedirectToAction("Details/" + id); }
            else
            { return View(p); }
        }//End Create Status

        // GET: Publications/EditStatus
        public ActionResult EditStatus(string pubid, string stepid)
        {
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(pubid);
            p.SelectedStepId = stepid;
            return View(p);
        }//End Edit Status

        // POST: Publications/EditStatus
        [HttpPost]
        public ActionResult EditStatus(FormCollection fc)
        {
            string id = fc["vmPublication.PublicationId"].ToString();
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(id);
            p.vmPublication.Statuses.Find(x => x.StepId == fc["StepId"]).StepDateTime = Convert.ToDateTime(fc["StepDateTime"]);
            if (Pubtracker2FrontEnd.ptHelper.Edit<ptPublication>(id, "publications", p.vmPublication))
            { return RedirectToAction("Details/" + id); }
            else
            { return View(p); }
        }//End Edit Status

        // GET: Publications/DeleteStatus
        public ActionResult DeleteStatus(string pubid, string stepid)
        {
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(pubid);
            p.SelectedStepId = stepid;
            return View(p);
        }//End Delete Status

        // POST: Publications/DeleteStatus
        [HttpPost]
        public ActionResult DeleteStatus(FormCollection fc)
        {
            string id = fc["vmPublication.PublicationId"].ToString();
            PublicationViewModel p = Pubtracker2FrontEnd.ptHelper.EditPubVM(id);
            p.vmPublication.Statuses.RemoveAll(x => x.StepId == fc["StepId"]);
            if (Pubtracker2FrontEnd.ptHelper.Edit<ptPublication>(id, "publications", p.vmPublication))
            { return RedirectToAction("Details/" + id); }
            else
            { return View(p); }
        }//End Delete Status

    }//end class
}//end namespace
