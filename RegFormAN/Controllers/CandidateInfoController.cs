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
    public class CandidateInfoController : Controller
    {
        private RegFormAngularNodeEntities db = new RegFormAngularNodeEntities();

        //
        // GET: /CandidateInfo/

        public ActionResult Index()
        {
            var candidate_details = db.CANDIDATE_DETAILS.Include("MANDATORYSKIL").Include("OPTIONALSKIL");
            return View(candidate_details.ToList());
        }

        //
        // GET: /CandidateInfo/Details/5

        public ActionResult Details(int id = 0)
        {
            CANDIDATE_DETAILS candidate_details = db.CANDIDATE_DETAILS.Single(c => c.CID == id);
            if (candidate_details == null)
            {
                return HttpNotFound();
            }
            return View(candidate_details);
        }

        //
        // GET: /CandidateInfo/Create

        public ActionResult Create()
        {
            ViewBag.MID = new SelectList(db.MANDATORYSKILS, "MID", "SKILL");
            ViewBag.OID = new SelectList(db.OPTIONALSKILS, "OID", "SKILL");
            return View();
        }

        //
        // POST: /CandidateInfo/Create

        [HttpPost]
        public ActionResult Create(CANDIDATE_DETAILS candidate_details)
        {
            if (ModelState.IsValid)
            {
                db.CANDIDATE_DETAILS.AddObject(candidate_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MID = new SelectList(db.MANDATORYSKILS, "MID", "SKILL", candidate_details.MID);
            ViewBag.OID = new SelectList(db.OPTIONALSKILS, "OID", "SKILL", candidate_details.OID);
            return View(candidate_details);
        }

        //
        // GET: /CandidateInfo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CANDIDATE_DETAILS candidate_details = db.CANDIDATE_DETAILS.Single(c => c.CID == id);
            if (candidate_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.MID = new SelectList(db.MANDATORYSKILS, "MID", "SKILL", candidate_details.MID);
            ViewBag.OID = new SelectList(db.OPTIONALSKILS, "OID", "SKILL", candidate_details.OID);
            return View(candidate_details);
        }

        //
        // POST: /CandidateInfo/Edit/5

        [HttpPost]
        public ActionResult Edit(CANDIDATE_DETAILS candidate_details)
        {
            if (ModelState.IsValid)
            {
                db.CANDIDATE_DETAILS.Attach(candidate_details);
                db.ObjectStateManager.ChangeObjectState(candidate_details, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MID = new SelectList(db.MANDATORYSKILS, "MID", "SKILL", candidate_details.MID);
            ViewBag.OID = new SelectList(db.OPTIONALSKILS, "OID", "SKILL", candidate_details.OID);
            return View(candidate_details);
        }

        //
        // GET: /CandidateInfo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CANDIDATE_DETAILS candidate_details = db.CANDIDATE_DETAILS.Single(c => c.CID == id);
            if (candidate_details == null)
            {
                return HttpNotFound();
            }
            return View(candidate_details);
        }

        //
        // POST: /CandidateInfo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CANDIDATE_DETAILS candidate_details = db.CANDIDATE_DETAILS.Single(c => c.CID == id);
            db.CANDIDATE_DETAILS.DeleteObject(candidate_details);
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