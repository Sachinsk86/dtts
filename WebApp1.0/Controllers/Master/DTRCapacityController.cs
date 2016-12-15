using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1._0.Models;

namespace WebApp1._0.Controllers
{
    public class DtrCapacityController : Controller
    {
        private DBContext _db = new DBContext();
        private DBContext obj = new DBContext();
        // GET: DtrCapacity
        public ActionResult Index()
        {
            try
            {
                DataTable dtrcapacity = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetDtrCapacityResult");
                obj.resultData = dtrcapacity;
                
            }
            catch(Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult SaveDtrCapacity(Model_mDtrCapacity dtr)
        {
            try
            {
                if (Request.Form["Save"] == "Save")
                {
                    if (dtr.dtrcapacityid == 0)
                    {
                        dtr.createdby = 1;
                        dtr.createddate = DateTime.Now;
                        dtr.active = true;
                        _db.Entry(dtr).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (dtr.dtrcapacityid > 0)
                        {
                            obj.usermessage = "Successfully Created Section";
                        }
                    }
                }
                else if (Request.Form["Save"] == "Update")
                {
                    dtr.modifiedby = 1;
                    dtr.modifieddate = DateTime.Now;
                    dtr.createdby = 1;
                    dtr.createddate = DateTime.Now;
                    dtr.active = true;
                    _db.Entry(dtr).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    if (dtr.dtrcapacityid > 0)
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
        public ActionResult EditDtrCapacity(int id)
        {
            DataTable dtrcapacity = new DataTable();
            try
            {
                if (id > 0)
                {
                    var list = new Dictionary<string, object>();
                    list.Add("dtrcapId", id);
                    dtrcapacity = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetDtrCapacityOnId", list);
                }
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            obj.resultData = dtrcapacity;
            return Json(new { obj_dtrcap = JsonConvert.SerializeObject(obj.resultData) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteDtrCapacity(int id)
        {
            try
            {
                (from x in _db.dtrCapacity
                 where x.dtrcapacityid == id
                 select x).ToList().ForEach(xx => xx.active = false);
                _db.SaveChanges();
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