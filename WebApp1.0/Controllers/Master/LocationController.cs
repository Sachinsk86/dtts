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
    public class LocationController : Controller
    {
        private DBContext _db = new DBContext();
        private DBContext obj = new DBContext();
        // GET: Division
        public ActionResult Index()
        {
            try
            {
                DataTable zones = sp.Sp_Generic_Class.GetMultipleRecord("Sp_getZones");
                obj.resultData = zones;

                DataTable LocationResults = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetLocationsResult");
                obj.resultView = LocationResults;
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult Index(Model_mlocation div)
        {
            try
            {
                if(Request.Form["Submit"] == "Submit")
                {
                    if (div.locationid == 0)
                    {
                        div.createdby = 1;
                        div.createddate = DateTime.Now;
                        div.modifiedby = 1;
                        div.modifieddate = DateTime.Now;
                        div.active = true;
                        _db.Entry(div).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (div.locationid > 0)
                        {
                            obj.usermessage = "Successfully Created Division";
                        }
                    }
                }else if(Request.Form["Submit"] == "Update")
                {
                    div.modifiedby = 1;
                    div.modifieddate = DateTime.Now;
                    div.createdby = 1;
                    div.createddate = DateTime.Now;
                    div.active = true;
                    _db.Entry(div).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    if (div.locationid > 0)
                    {
                        obj.usermessage = "Successfully Updated Circle";
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
        public ActionResult getLocationOnId(int id)
        {
            DataTable loc = new DataTable();
            try
            {
                var list = new Dictionary<string, object>();
                list.Add("locId", id);
                loc = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetLocationOnId", list);
                obj.resultData = loc;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            obj.resultData = loc;
            return Json(new { obj_loc = JsonConvert.SerializeObject(obj.resultData) }, JsonRequestBehavior.AllowGet);
        }
    }
}