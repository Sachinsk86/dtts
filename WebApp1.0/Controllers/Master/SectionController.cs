using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1._0.Models;

namespace WebApp1._0.Controllers.Master
{
    public class SectionController : Controller
    {
        private DBContext _db = new DBContext();
        private DBContext obj = new DBContext();
        // GET: Section
        public ActionResult Index()
        {
            DataRowCollection subdiv = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetSubDivResult");
            DataRowCollection secRes = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetSectionResult");
            foreach (DataRow rows in subdiv)
            {
                obj.obj_subdivResult.Add(new Model_subDivResult
                {
                    subdivisionid = Convert.ToInt32(rows["subdivisionid"]),
                    subdivisionname = Convert.ToString(rows["subdivisionname"]),
                });
            }
            foreach (DataRow sec in secRes)
            {
                obj.obj_sectionResult.Add(new Model_sectionResult
                {
                    sectionid = Convert.ToInt32(sec["sectionid"]),
                    sectionname = Convert.ToString(sec["sectionname"]),
                    subdivisionname = Convert.ToString(sec["subdivisionname"]),
                });
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult SaveSection(Model_msection sec)
        {
            
            try
            {
                if (Request.Form["Submit"] == "Submit") 
                {
                    if (sec.sectionid == 0)
                    {
                        sec.createdby = 1;
                        sec.createddate = DateTime.Now;
                        sec.modifiedby = 1;
                        sec.modifieddate = DateTime.Now;
                        sec.active = true;
                        _db.Entry(sec).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (sec.sectionid > 0)
                        {
                            obj.usermessage = "Successfully Created Section";
                        }
                    }
                }
                else if (Request.Form["Submit"] == "Update")
                {
                    sec.modifiedby = 1;
                    sec.modifieddate = DateTime.Now;
                    sec.createdby = 1;
                    sec.createddate = DateTime.Now;
                    sec.active = true;
                    _db.Entry(sec).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    if (sec.sectionid > 0)
                    {
                        obj.usermessage = "Successfully Updated Section";
                    }
                }
                
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return RedirectToAction("Index");
        }
        public ActionResult EditSection(int id)
        {
            var list = new Dictionary<string,object>();
            list.Add("secId",id);
            DataRowCollection section = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetSectionsOnId", list);
            foreach (DataRow rows in section)
            {
                obj.obj_sectionResult.Add(new Model_sectionResult 
                {
                    sectionid = Convert.ToInt32(rows["sectionid"]),
                    sectionname = Convert.ToString(rows["sectionname"]),
                    sectioncode = Convert.ToInt32(rows["sectioncode"]),
                    subdivisionname = Convert.ToString(rows["subdivisionname"]),
                    ref_subdivisionid = Convert.ToInt32(rows["ref_subdivisionid"]),
                });
            }
            return Json(new { obj_sec = obj.obj_sectionResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteSec(int id)
        {
            var list = new Dictionary<string, object>();
            list.Add("secId", id);
            sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_deleteSection", list);
            return Json(new { },JsonRequestBehavior.AllowGet);
        }
    }
}