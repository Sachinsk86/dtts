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
    public class FeederController : Controller
    {
        private DBContext _db = new DBContext();
        private DBContext obj = new DBContext();
        // GET: Feeder
        public ActionResult Index()
        {
            try
            {
                DataTable feederType = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetFeederTypeResult");
                obj.resultData = feederType;

                DataTable fcategory = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetFeederCategoryResult");
                obj.resultVal = fcategory;

                DataTable substation = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetSubStationResult");
                obj.resultView = substation;

                DataTable feeder = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetFeederResult");
                obj.resultArray = feeder;
            }

            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult SaveFeeder(Model_Feeder feeder)
        {
            try
            {
                if (Request.Form["Save"] == "Save")
                {
                    if (feeder.feederid == 0)
                    {
                        feeder.createdby = 1;
                        feeder.createddate = DateTime.Now;
                        feeder.active = true;
                        _db.Entry(feeder).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (feeder.feederid > 0)
                        {
                            obj.usermessage = "Successfully Created Zone";
                        }
                    }
                }
                else if (Request.Form["Save"] == "Update")
                {
                    feeder.modifiedby = 1;
                    feeder.modifieddate = DateTime.Now;
                    feeder.createdby = 1;
                    feeder.createddate = DateTime.Now;
                    feeder.active = true;
                    _db.Entry(feeder).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    if (feeder.feederid > 0)
                    {
                        obj.usermessage = "Successfully Updated Circle";
                    }
                }
            }
            catch(Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return RedirectToAction("Index");
        }
        public ActionResult EditFeeder(int id)
        {
            DataTable editFeeder = new DataTable();
            try
            {
                if (id > 0) 
                {
                    var list = new Dictionary<string, object>();
                    list.Add("feederId", id);
                    editFeeder = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetFeedersOnId", list);
                    
                }
                
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            obj.resultData = editFeeder;
            return Json(new { obj_feeder = JsonConvert.SerializeObject(obj.resultData) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteFeeder(int id)
        {
            try
            {
                if (id > 0)
                {
                    var list = new Dictionary<string, object>();
                    list.Add("feederId", id);
                    var editFeeder = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_DeleteFeedersOnId", list);

                }
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}