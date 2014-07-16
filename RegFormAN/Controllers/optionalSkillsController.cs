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
    public class optionalSkillsController : Controller
    {
        private RegFormAngularNodeEntities db = new RegFormAngularNodeEntities();

        //
        // GET: /optionalSkills/

        public ActionResult Index()
        {
            var optionalskils = db.OPTIONALSKILS.Include("INTERVIEWER").Include("Rating").Include("Rating1");
            return View(optionalskils.ToList());
        }

        //
        // GET: /optionalSkills/Details/5

        public ActionResult Details(int id = 0)
        {
            OPTIONALSKIL optionalskil = db.OPTIONALSKILS.Single(o => o.OID == id);
            if (optionalskil == null)
            {
                return HttpNotFound();
            }
            return View(optionalskil);
        }

        //
        // GET: /optionalSkills/Create

        public ActionResult Create()
        {
            ViewBag.IID = new SelectList(db.INTERVIEWERs, "IID", "INAME");
            ViewBag.INTERVIEWERRATING = new SelectList(db.Ratings, "RID", "Description");
            ViewBag.JRSS = new SelectList(db.Ratings, "RID", "Description");
            return View();
        }

        //
        // POST: /optionalSkills/Create

        //[HttpPost]
        public ActionResult Create(OPTIONALSKIL optionalskil)
        {
            if (ModelState.IsValid)
            {
                db.OPTIONALSKILS.AddObject(optionalskil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IID = new SelectList(db.INTERVIEWERs, "IID", "INAME", optionalskil.IID);
            ViewBag.INTERVIEWERRATING = new SelectList(db.Ratings, "RID", "Description", optionalskil.INTERVIEWERRATING);
            ViewBag.JRSS = new SelectList(db.Ratings, "RID", "Description", optionalskil.JRSS);
            return View(optionalskil);
        }

        //
        // GET: /optionalSkills/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OPTIONALSKIL optionalskil = db.OPTIONALSKILS.Single(o => o.OID == id);
            if (optionalskil == null)
            {
                return HttpNotFound();
            }
            ViewBag.IID = new SelectList(db.INTERVIEWERs, "IID", "INAME", optionalskil.IID);
            ViewBag.INTERVIEWERRATING = new SelectList(db.Ratings, "RID", "Description", optionalskil.INTERVIEWERRATING);
            ViewBag.JRSS = new SelectList(db.Ratings, "RID", "Description", optionalskil.JRSS);
            return View(optionalskil);
        }

        //
        // POST: /optionalSkills/Edit/5

        [HttpPost]
        public ActionResult Edit(OPTIONALSKIL optionalskil)
        {
            if (ModelState.IsValid)
            {
                db.OPTIONALSKILS.Attach(optionalskil);
                db.ObjectStateManager.ChangeObjectState(optionalskil, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IID = new SelectList(db.INTERVIEWERs, "IID", "INAME", optionalskil.IID);
            ViewBag.INTERVIEWERRATING = new SelectList(db.Ratings, "RID", "Description", optionalskil.INTERVIEWERRATING);
            ViewBag.JRSS = new SelectList(db.Ratings, "RID", "Description", optionalskil.JRSS);
            return View(optionalskil);
        }

        //
        // GET: /optionalSkills/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OPTIONALSKIL optionalskil = db.OPTIONALSKILS.Single(o => o.OID == id);
            if (optionalskil == null)
            {
                return HttpNotFound();
            }
            return View(optionalskil);
        }

        //
        // POST: /optionalSkills/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            OPTIONALSKIL optionalskil = db.OPTIONALSKILS.Single(o => o.OID == id);
            db.OPTIONALSKILS.DeleteObject(optionalskil);
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