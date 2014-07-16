using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
namespace RegFormAN.Models
{
  public class RegFormModel
  {



    //public class INTERVIEWERModel
    //{
    public int IID { get; set; }
    public string INAME { set; get; }
    public string SIGN { set; get; }

    //}

    //public class RatingModel
    //{
    public int RID { get; set; }
    public string Description { set; get; }
    //}


    //public class MANDATORYSKILModel : INTERVIEWERModel
    //{
    public int MID { get; set; }
    public string Mskill { set; get; }
    public string MJRSS { set; get; }
    //public string INTERVIEWERRATING { get; set; }
    //public INTERVIEWER IID { get; set; }

    //}

    //public class OPTIONALSKILModel : INTERVIEWERModel
    //{
    public int OID { get; set; }
    public string Oskill { set; get; }
    public string OJRSS { set; get; }
    //  public string INTERVIEWERRATING { get; set; }
    //  public INTERVIEWER IID { get; set; }

    //}

    //public class CANDIDATE_DETAILS : MANDATORYSKILModel, OPTIONALSKILModel
    //{ 
    public int CID { set; get; }
    public string CANDIDATE_NAME { get; set; }
    public string PROJECT { get; set; }
    public string PRACTICE_AREA { set; get; }
    public string Requester { get; set; }
    public DateTime? Date { get; set; }
    //  public MANDATORYSKILModel MID { get; set; }
    //  public OPTIONALSKILModel OID { get; set; }

    //}
  }

}