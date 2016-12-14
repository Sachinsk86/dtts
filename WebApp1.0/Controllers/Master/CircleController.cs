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
    public class CircleController : Controller
    {
        private DBContext _db = new DBContext();
        private DBContext obj = new DBContext();
        // GET: Circle
        public ActionResult Index()
        {
            try
            {
                DataTable zone = sp.Sp_Generic_Class.GetMultipleRecord("Sp_getZones");
                obj.resultData = zone;

                DataTable cdata = sp.Sp_Generic_Class.GetMultipleRecord("Sp_getCircleDetails");
                obj.resultView = cdata;
                //foreach (DataRow rows in zone)
                //{
                //    obj.obj_zone.Add(new Model_mzone
                //    {
                //        zoneid = Convert.ToByte(rows["zoneid"]),
                //        zonename = Convert.ToString(rows["zonename"]),
                //    });
                //}
                //foreach (DataRow row in cdata)
                //{
                //    obj.obj_circlrResult.Add(new Model_mcircleResult
                //    {
                //        circleid = Convert.ToByte(row["circleid"]),
                //        circlecode = Convert.ToByte(row["circlecode"]),
                //        circlename = Convert.ToString(row["circlename"]),
                //        zonename = Convert.ToString(row["zonename"]),
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
        public ActionResult SaveCircle(Model_mcircle c)
        {
            try
            {
                if (Request.Form["Save"] == "Save")
                {
                    if (c.circleid == 0)
                    {
                        c.createdby = 1;
                        c.createddate = DateTime.Now;
                        c.active = true;
                        _db.Entry(c).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (c.circleid > 0)
                        {
                            obj.usermessage = "Successfully Created Circle";
                        }
                    }
                }
                else if (Request.Form["Save"] == "Update")
                {
                    c.modifiedby = 1;
                    c.modifieddate = DateTime.Now;
                    c.createdby = 1;
                    c.createddate = DateTime.Now;
                    c.active = true;
                    _db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    if (c.circleid > 0)
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
        public ActionResult EditCircle(int id)
        {
            DataTable circle = new DataTable();
            try
            {
                if (id > 0)
                {
                    var list = new Dictionary<string, object>();
                    list.Add("circleId", id);
                    circle = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetCircleOnId", list);
                }
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            obj.resultData = circle;
            return Json(new { obj_circle = JsonConvert.SerializeObject(obj.resultData) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteCircle(int id)
        {
            try 
            {
                if (id >0)
                {
                    var list = new Dictionary<string, object>();
                    list.Add("circleId", id);
                    sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_deleteCircleOnId", list);
                }
                
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return Json (new {},JsonRequestBehavior.AllowGet);
        }
    }
}