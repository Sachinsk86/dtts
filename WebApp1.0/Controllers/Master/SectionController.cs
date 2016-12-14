using Newtonsoft.Json;
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
            try 
            {
                DataTable subdiv = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetSubDivResult");
                obj.resultData = subdiv;

                DataTable secRes = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetSectionResult");
                obj.resultView = secRes;
                //foreach (DataRow rows in subdiv)
                //{
                //    obj.obj_subdivResult.Add(new Model_subDivResult
                //    {
                //        subdivisionid = Convert.ToInt32(rows["subdivisionid"]),
                //        subdivisionname = Convert.ToString(rows["subdivisionname"]),
                //    });
                //}
                //foreach (DataRow sec in secRes)
                //{
                //    obj.obj_sectionResult.Add(new Model_sectionResult
                //    {
                //        sectionid = Convert.ToInt32(sec["sectionid"]),
                //        sectionname = Convert.ToString(sec["sectionname"]),
                //        sectioncode = Convert.ToInt32(sec["sectioncode"]),
                //        subdivisionname = Convert.ToString(sec["subdivisionname"]),
                //    });
                //}
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult SaveSection(Model_msection sec)
        {
            
            try
            {
                if (Request.Form["Save"] == "Save") 
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
                else if (Request.Form["Save"] == "Update")
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
            DataTable section = new DataTable();
            try
            {
                if (id > 0)
                {
                    var list = new Dictionary<string, object>();
                    list.Add("secId", id);
                     section = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetSectionsOnId", list);
                }
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            obj.resultData = section;
            return Json(new { obj_section = JsonConvert.SerializeObject(obj.resultData) }, JsonRequestBehavior.AllowGet);
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