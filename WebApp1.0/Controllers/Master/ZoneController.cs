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
    public class ZoneController : Controller
    {
        private DBContext _db = new DBContext();
        private DBContext obj = new DBContext();
        // GET: Master
        public ActionResult Index()
        {
            try
            {
                DataTable corp = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetCorporate");
                obj.resultData = corp;
                DataTable zdata = sp.Sp_Generic_Class.GetMultipleRecord("Sp_getZoneDetails");
                obj.resultView = zdata;

                //foreach (DataRow row in corp)
                //{
                //    obj.obj_corporate.Add(new Model_mcorporate
                //    {
                //        corporateid = Convert.ToByte(row["corporateid"]),
                //        corporatename = Convert.ToString(row["corporatename"]),
                //    });
                //}
                //foreach (DataRow rows in zdata)
                //{
                //    obj.obj_zoneResult.Add(new Model_mzoneResult
                //    {
                //        zoneid = Convert.ToByte(rows["zoneid"]),
                //        zonecode = Convert.ToByte(rows["zonecode"]),
                //        zonename = Convert.ToString(rows["zonename"]),
                //        corporatename = Convert.ToString(rows["corporatename"]),

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
        public ActionResult SaveZone(Model_mzone z) 
        {
            try
            {
                if (Request.Form["Save"] == "Save")
                {
                    if (z.zoneid == 0)
                    {
                        z.createdby = 1;
                        z.createddate = DateTime.Now;
                        z.active = true;
                        _db.Entry(z).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (z.zoneid > 0)
                        {
                            obj.usermessage = "Successfully Created Zone";
                        }
                    }
                }
                else if (Request.Form["Save"] == "Update")
                {
                    z.modifiedby = 1;
                    z.modifieddate = DateTime.Now;
                    z.createdby = 1;
                    z.createddate = DateTime.Now;
                    z.active = true;
                    _db.Entry(z).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    if (z.zoneid > 0)
                    {
                        obj.usermessage = "Successfully Updated Zone";
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

        public ActionResult EditZone(int id)
        {
            DataTable zone = new DataTable();
            try
            {
                var list = new Dictionary<string, object>();
                list.Add("zoneId", id);
                zone = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetZoneOnId", list);
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            obj.resultData = zone;
            return Json(new { obj_zone = JsonConvert.SerializeObject(obj.resultData) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteZone(int id)
        {
            var list = new Dictionary<string, object>();
            list.Add("zoneId", id);
            sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_deleteZoneOnId", list);
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}
