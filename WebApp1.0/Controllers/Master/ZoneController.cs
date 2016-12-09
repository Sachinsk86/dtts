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
            DataRowCollection corp = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetCorporate");
            DataRowCollection zdata = sp.Sp_Generic_Class.GetMultipleRecord("Sp_getZoneDetails");
            foreach (DataRow row in corp)
            {
                obj.obj_corporate.Add(new Model_mcorporate
                {
                    corporateid = Convert.ToInt32(row["corporateid"]),
                    corporatename = Convert.ToString(row["corporatename"]),
                });
            }
            foreach (DataRow rows in zdata)
            {
                obj.obj_zoneResult.Add(new Model_mzoneResult
                {
                    zoneid = Convert.ToInt32(rows["zoneid"]),
                    zonecode = Convert.ToInt32(rows["zonecode"]),
                    zonename = Convert.ToString(rows["zonename"]),
                    corporatename = Convert.ToString(rows["corporatename"]),

                });
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult SaveZone(Model_mzone z) 
        {
            try
            {
                if(Request.Form["Submit"] == "Submit")
                {
                    if (z.zoneid == 0)
                    {
                        z.createdby = 1;
                        z.createddate = DateTime.Now;
                        z.modifiedby = 1;
                        z.modifieddate = DateTime.Now;
                        z.active = true;
                        _db.Entry(z).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (z.zoneid > 0)
                        {
                            obj.usermessage = "Successfully Created Zone";
                        }
                    }
                }
                else if (Request.Form["Submit"] == "Update")
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
            var list = new Dictionary<string, object>();
            list.Add("zoneId", id);
            DataRowCollection zone = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetZoneOnId", list);
            foreach (DataRow rows in zone)
            {
                obj.obj_zone.Add(new Model_mzone 
                {
                    zoneid = Convert.ToInt32(rows["zoneid"]),
                    zonecode = Convert.ToInt32(rows["zonecode"]),
                    zonename = Convert.ToString(rows["zonename"]),
                    ref_corporateid = Convert.ToInt32(rows["ref_corporateid"]),
                });
            }
            return Json(new { obj_zone = obj.obj_zone }, JsonRequestBehavior.AllowGet);
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
