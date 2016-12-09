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
            DataRowCollection zone = sp.Sp_Generic_Class.GetMultipleRecord("Sp_getZones");
            DataRowCollection cdata = sp.Sp_Generic_Class.GetMultipleRecord("Sp_getCircleDetails");
            foreach (DataRow rows in zone)
            {
                obj.obj_zone.Add(new Model_mzone
                {
                    zoneid = Convert.ToInt32(rows["zoneid"]),
                    zonename = Convert.ToString(rows["zonename"]),
                });
            }
            foreach (DataRow row in cdata)
            {
                obj.obj_circlrResult.Add(new Model_mcircleResult
                {
                    circleid = Convert.ToInt32(row["circleid"]),
                    circlecode = Convert.ToInt32(row["circlecode"]),
                    circlename = Convert.ToString(row["circlename"]),
                    zonename = Convert.ToString(row["zonename"]),
                });
                
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult SaveCircle(Model_mcircle c)
        {
            try
            {
                if(Request.Form["Submit"] == "Submit")
                {
                    if (c.circleid == 0)
                    {
                        c.createdby = 1;
                        c.createddate = DateTime.Now;
                        c.modifiedby = 1;
                        c.modifieddate = DateTime.Now;
                        c.active = true;
                        _db.Entry(c).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (c.circleid > 0)
                        {
                            obj.usermessage = "Successfully Created Circle";
                        }
                    }
                }
                else if (Request.Form["Submit"] == "Update")
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
            var list = new Dictionary<string, object>();
            list.Add("circleId", id);
            DataRowCollection circle = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetCircleOnId", list);
            foreach (DataRow rows in circle)
            {
                obj.obj_circle.Add(new Model_mcircle
                {
                    circleid = Convert.ToInt32(rows["circleid"]),
                    circlecode = Convert.ToInt32(rows["circlecode"]),
                    circlename = Convert.ToString(rows["circlename"]),
                    ref_zoneid = Convert.ToInt32(rows["ref_zoneid"]),
                });
            }
            return Json(new { obj_circle = obj.obj_circle }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteCircle(int id)
        {
            var list = new Dictionary<string, object>();
            list.Add("circleId", id);
            sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_deleteCircleOnId",list);
            return Json (new {},JsonRequestBehavior.AllowGet);
        }
    }
}