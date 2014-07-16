using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegFormAN.Models;

namespace RegFormAN.Controllers
{
    public class InterviewerController : Controller
    {
        private RegFormAngularNodeEntities db = new RegFormAngularNodeEntities();

        //
        // GET: /Interviewer/

        public ActionResult Index()
        {
            return View(db.INTERVIEWERs.ToList());
        }

        //
        // GET: /Interviewer/Details/5

        public ActionResult Details(int id = 0)
        {
            INTERVIEWER interviewer = db.INTERVIEWERs.Single(i => i.IID == id);
            if (interviewer == null)
            {
                return HttpNotFound();
            }
            return View(interviewer);
        }

        //
        // GET: /Interviewer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Interviewer/Create

        [HttpPost]
        public ActionResult Create(INTERVIEWER interviewer)
        {
            if (ModelState.IsValid)
            {
                db.INTERVIEWERs.AddObject(interviewer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interviewer);
        }

        //
        // GET: /Interviewer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            INTERVIEWER interviewer = db.INTERVIEWERs.Single(i => i.IID == id);
            if (interviewer == null)
            {
                return HttpNotFound();
            }
            return View(interviewer);
        }

        //
        // POST: /Interviewer/Edit/5

        [HttpPost]
        public ActionResult Edit(INTERVIEWER interviewer)
        {
            if (ModelState.IsValid)
            {
                db.INTERVIEWERs.Attach(interviewer);
                db.ObjectStateManager.ChangeObjectState(interviewer, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interviewer);
        }

        //
        // GET: /Interviewer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            INTERVIEWER interviewer = db.INTERVIEWERs.Single(i => i.IID == id);
            if (interviewer == null)
            {
                return HttpNotFound();
            }
            return View(interviewer);
        }

        //
        // POST: /Interviewer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            INTERVIEWER interviewer = db.INTERVIEWERs.Single(i => i.IID == id);
            db.INTERVIEWERs.DeleteObject(interviewer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}