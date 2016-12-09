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
            DataRowCollection zones = sp.Sp_Generic_Class.GetMultipleRecord("Sp_getZones");
            DataRowCollection LocationResults = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetLocationsResult");
            foreach (DataRow row in zones)
            {
                obj.obj_zone.Add(new Model_mzone
                {
                    zoneid = Convert.ToInt32(row["zoneid"]),
                    zonename = Convert.ToString(row["zonename"]),
                });
            }
            foreach (DataRow div in LocationResults)
            {
                obj.obj_transformerSuppCode.Add(new Model_TransformerSuppResult
                {
                    locationid = Convert.ToInt32(div["locationid"]),
                    locationname = Convert.ToString(div["locationname"]),
                    zonename = Convert.ToString(div["zonename"]),
                    circlename = Convert.ToString(div["circlename"]),
                    divisionname = Convert.ToString(div["divisionname"]),
                    subdivisionname = Convert.ToString(div["subdivisionname"]),
                    sectionname = Convert.ToString(div["sectionname"])                  
                });
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult Index(Model_mlocation div)
        {
            try
            {
                   if(div.locationid==0)
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
                   
                    //if (div.divisionid > 0)
                    //{
                    //    obj.usermessage = "Successfully Created Division";
                    //}
                
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return RedirectToAction("Index");
        }
        public ActionResult getLocationOnId(Model_TransformerFilter filter,int id)
        {
            try
            {
                
                var list = new Dictionary<string, object>();
                list.Add("locationid", id);
                DataRowCollection userDet = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetUserDetailsOnId", list);
                foreach (DataRow rows in userDet)
                {
                    obj.obj_transformerSuppCode.Add(new Model_TransformerSuppResult
                    {
                        locationid = Convert.ToInt32(rows["userid"]),
                        locationname = Convert.ToString(rows["locationname"]),
                        //ref_zoneid = Convert.ToInt32(rows["userid"]),
                        zonename = Convert.ToString(rows["locationname"]),
                       // ref_circleid = Convert.ToInt32(rows["userid"]),
                        circlename = Convert.ToString(rows["locationname"]),
                       // ref_divisionid = Convert.ToInt32(rows["userid"]),
                        divisionname = Convert.ToString(rows["locationname"]),
                        
                    });
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return Json(new { obj_user = obj.obj_transformerSuppCode }, JsonRequestBehavior.AllowGet);
        }
    }
}