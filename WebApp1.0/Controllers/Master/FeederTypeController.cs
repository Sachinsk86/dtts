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
    public class FeederTypeController : Controller
    {
        private DBContext _db = new DBContext();
        private DBContext obj = new DBContext();
        // GET: Feeder
        public ActionResult Index()
        {
            try 
            {
                DataTable feeder = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetFeederTypeResult");
                obj.resultData = feeder;
                /*foreach (DataRow rows in feeder)
                {
                    obj.obj_feeder.Add(new Model_mfeeder
                    {
                        feedertypeid = Convert.ToInt32(rows["feedertypeid"]),
                        feedertypename = Convert.ToString(rows["feedertypename"]),
                    });
                }*/
            }
            
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult SaveFeederType(Model_mfeeder feeder)
        {
            try
            {
                if (Request.Form["Save"] == "Save")
                {
                    if (feeder.feedertypeid == 0)
                    {
                        feeder.createdby = 1;
                        feeder.createddate = DateTime.Now;
                        feeder.active = true;
                        _db.Entry(feeder).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (feeder.feedertypeid > 0)
                        {
                            obj.usermessage = "Successfully Created Section";
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
                    if (feeder.feedertypeid > 0)
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
        public ActionResult EditFeederType(int id)
        {
            DataTable feederType = new DataTable();
            try
            {
                if(id > 0)
                {
                    var list = new Dictionary<string, object>();
                    list.Add("fTypeId", id);
                    feederType =  sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetFeederTypeOnId", list);
                }
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            obj.resultData = feederType;
            return Json(new { ftype = JsonConvert.SerializeObject(obj.resultData) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteFeederType(int id)
        {
            try 
            {
                if(id > 0)
                {
                    var list = new Dictionary<string, object>();
                    list.Add("feederId",id);
                    sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_DeleteFeederOnId",list);
                }
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return Json(new {},JsonRequestBehavior.AllowGet);
        }
    }
}