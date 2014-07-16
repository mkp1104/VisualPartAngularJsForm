using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegFormAN.Models;

namespace RegFormAN.Controllers
{
    public class RegFormAngNodeController : Controller
    {
        //
        // GET: /RegFormAngNode/

      private RegFormAngularNodeEntities db = new RegFormAngularNodeEntities();

      [HttpGet]
      public JsonResult GetCandidateDetails()
      {

        var candidateDetails = new List<RegFormModel>();
        
        candidateDetails = (from intr in db.INTERVIEWERs 
                           join mndskill in db.MANDATORYSKILS on intr.IID equals mndskill.IID
                           join ordskill in db.OPTIONALSKILS on intr.IID equals ordskill.IID 
                           join rt in db.Ratings on mndskill.JRSS equals rt.RID 
                           join rt1 in db.Ratings on ordskill.JRSS equals rt1.RID
                           join rt2 in db.Ratings on mndskill.INTERVIEWERRATING equals rt2.RID
                           join rt3 in db.Ratings on ordskill.INTERVIEWERRATING equals rt3.RID
                           join candidate in db.CANDIDATE_DETAILS on mndskill.MID equals candidate.MID
                           join candidate1 in db.CANDIDATE_DETAILS on ordskill.OID equals candidate1.OID
                           select new RegFormModel { IID = intr.IID,INAME = intr.INAME,SIGN = intr.SIGN,RID = rt.RID,Description = rt.Description,MID = mndskill.MID,Mskill = mndskill.SKILL,MJRSS = mndskill.Rating.Description,OID = ordskill.OID,Oskill = ordskill.SKILL,OJRSS = ordskill.Rating.Description,CID = candidate.CID,CANDIDATE_NAME = candidate.CANDIDATE_NAME,PROJECT = candidate.PROJECT,PRACTICE_AREA = candidate.PRACTICE_AREA,Requester = candidate.Requester,Date = candidate.Date }).ToList();
        
       
        return Json(candidateDetails, JsonRequestBehavior.AllowGet);
      }
      private static string _candidateName;
      private static string _projectName;
      private static string _practiceArea;
      private static string _requester;
      private static string _interviewsName;
      private static string _sign;
      private static DateTime _date;
      private static string _mandatorySkill;
      private static string _mandatoryJrssRating;
      private static string _interviewsRating;
      private static string _optionalSkill;
      private static string _optionalJrssRating;
      private static string _interviewersRating;
      private static string _comments;
      [HttpPost]
      public ActionResult CreateCandidateDetails(string candidateName,string projectName,string practiceArea,string requester,
        string interviewsName,string sign, DateTime date,string mandatorySkill,string mandatoryJrssRating,string interviewsRating,
        string optionalSkill,string optionalJrssRating,string interviewersRating,string comments)
      {
        _interviewsName = interviewsName;




        return View();
      }
      //create interviewerDetails:-

      public int Create(INTERVIEWER interviewer)
      {
        if (ModelState.IsValid)
        {
          db.INTERVIEWERs.AddObject(interviewer);
          db.SaveChanges();
          return db.INTERVIEWERs.Select(i=>i.IID).First();
        }

        return 124;
      }
      //create MANDATORYSKILLS:--
      public int CreateMandatorySkills(MANDATORYSKIL mandatoryskil)
      {
        if (ModelState.IsValid)
        {
          db.MANDATORYSKILS.AddObject(mandatoryskil);
          db.SaveChanges();
          return db.MANDATORYSKILS.Select(i=>i.MID).First();
        }

        //ViewBag.IID = new SelectList(db.INTERVIEWERs, "IID", "INAME", mandatoryskil.IID);
        //ViewBag.INTERVIEWERRATING = new SelectList(db.Ratings, "RID", "Description", mandatoryskil.INTERVIEWERRATING);
        //ViewBag.JRSS = new SelectList(db.Ratings, "RID", "Description", mandatoryskil.JRSS);
        return 123;
      }

      //create optionalSkills:--
      public int CreateOptionalSkills(OPTIONALSKIL optionalskil)
      {
        if (ModelState.IsValid)
        {
          db.OPTIONALSKILS.AddObject(optionalskil);
          db.SaveChanges();
          return db.OPTIONALSKILS.Select(i=>i.OID).First();
        }

        return 145;
      }

      //create candidate:--
      public ActionResult CreateCandidate(CANDIDATE_DETAILS candidate_details)
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


        //public ActionResult Index()
        //{
        //    return View();
        //}

    }
}
