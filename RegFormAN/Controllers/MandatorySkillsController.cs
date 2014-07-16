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
    public class MandatorySkillsController : Controller
    {
        private RegFormAngularNodeEntities db = new RegFormAngularNodeEntities();

        //
        // GET: /MandatorySkills/

        public ActionResult Index()
        {
            var mandatoryskils = db.MANDATORYSKILS.Include("INTERVIEWER").Include("Rating").Include("Rating1");
            return View(mandatoryskils.ToList());
        }

        //
        // GET: /MandatorySkills/Details/5

        public ActionResult Details(int id = 0)
        {
            MANDATORYSKIL mandatoryskil = db.MANDATORYSKILS.Single(m => m.MID == id);
            if (mandatoryskil == null)
            {
                return HttpNotFound();
            }
            return View(mandatoryskil);
        }

        //
        // GET: /MandatorySkills/Create

        public ActionResult Create()
        {
            ViewBag.IID = new SelectList(db.INTERVIEWERs, "IID", "INAME");
            ViewBag.INTERVIEWERRATING = new SelectList(db.Ratings, "RID", "Description");
            ViewBag.JRSS = new SelectList(db.Ratings, "RID", "Description");
            return View();
        }

        //
        // POST: /MandatorySkills/Create

        [HttpPost]
        public ActionResult Create(MANDATORYSKIL mandatoryskil)
        {
            if (ModelState.IsValid)
            {
                db.MANDATORYSKILS.AddObject(mandatoryskil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IID = new SelectList(db.INTERVIEWERs, "IID", "INAME", mandatoryskil.IID);
            ViewBag.INTERVIEWERRATING = new SelectList(db.Ratings, "RID", "Description", mandatoryskil.INTERVIEWERRATING);
            ViewBag.JRSS = new SelectList(db.Ratings, "RID", "Description", mandatoryskil.JRSS);
            return View(mandatoryskil);
        }

        //
        // GET: /MandatorySkills/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MANDATORYSKIL mandatoryskil = db.MANDATORYSKILS.Single(m => m.MID == id);
            if (mandatoryskil == null)
            {
                return HttpNotFound();
            }
            ViewBag.IID = new SelectList(db.INTERVIEWERs, "IID", "INAME", mandatoryskil.IID);
            ViewBag.INTERVIEWERRATING = new SelectList(db.Ratings, "RID", "Description", mandatoryskil.INTERVIEWERRATING);
            ViewBag.JRSS = new SelectList(db.Ratings, "RID", "Description", mandatoryskil.JRSS);
            return View(mandatoryskil);
        }

        //
        // POST: /MandatorySkills/Edit/5

        [HttpPost]
        public ActionResult Edit(MANDATORYSKIL mandatoryskil)
        {
            if (ModelState.IsValid)
            {
                db.MANDATORYSKILS.Attach(mandatoryskil);
                db.ObjectStateManager.ChangeObjectState(mandatoryskil, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.IID = new SelectList(db.INTERVIEWERs, "IID", "INAME", mandatoryskil.IID);
            //ViewBag.INTERVIEWERRATING = new SelectList(db.Ratings, "RID", "Description", mandatoryskil.INTERVIEWERRATING);
            //ViewBag.JRSS = new SelectList(db.Ratings, "RID", "Description", mandatoryskil.JRSS);
            //return View(mandatoryskil);
        }

        //
        // GET: /MandatorySkills/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MANDATORYSKIL mandatoryskil = db.MANDATORYSKILS.Single(m => m.MID == id);
            if (mandatoryskil == null)
            {
                return HttpNotFound();
            }
            return View(mandatoryskil);
        }

        //
        // POST: /MandatorySkills/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MANDATORYSKIL mandatoryskil = db.MANDATORYSKILS.Single(m => m.MID == id);
            db.MANDATORYSKILS.DeleteObject(mandatoryskil);
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