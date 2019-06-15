using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAPIdotNET_starter.Controllers.Base;
using MVCAPIdotNET_starter.Models.Domain.DB;
using MVCAPIdotNET_starter.Models.Dto.Authentication;
using MVCAPIdotNET_starter.Services;

namespace MVCAPIdotNET_starter.Controllers
{
    public class GroupsController : BaseAppController
    {
        private GroupService GroupService = new GroupService(ContextualOrganization.InstanceGuid);

        // GET: Groups
        public ActionResult Index()
        {
            return View(GroupService.GetList());
        }


        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InserOrUpdate([Bind(Include = "Id,Name,Description,GroupType")] DtoGroup group)
        {
            if (ModelState.IsValid)
            {
                if(group.Id != Guid.Empty)
                    GroupService.Update(group);
                else
                    GroupService.Insert(group);
            }

            return RedirectToAction("Index");
        }



        // GET: Groups/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DtoGroup group = GroupService.Get(id.Value);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DtoGroup group = GroupService.Get(id.Value);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,GroupType")] DtoGroup group)
        {
            if (ModelState.IsValid)
            {
                GroupService.Update(group);
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DtoGroup group = GroupService.Get(id.Value);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GroupService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GroupService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
