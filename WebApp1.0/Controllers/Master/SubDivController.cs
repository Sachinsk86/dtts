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
    
    public class SubDivController : Controller
    {
        private DBContext _db = new DBContext();
        private DBContext obj = new DBContext();
        // GET: SubDiv
        public ActionResult Index()
        {
            try
            {
                DataTable divs = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetDivisionsResult");
                obj.resultData = divs;

                DataTable subDiv = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetSubDivResult");
                obj.resultView = subDiv;

                //foreach (DataRow row in divs)
                //{
                //    obj.obj_divResult.Add(new Model_mdivResult
                //    {
                //        divisionid = Convert.ToByte(row["divisionid"]),
                //        divisionname = Convert.ToString(row["divisionname"]),
                //    });
                //}
                //foreach (DataRow rows in subDiv)
                //{
                //    obj.obj_subdivResult.Add(new Model_subDivResult
                //    {
                //        subdivisionid = Convert.ToInt32(rows["subdivisionid"]),
                //        subdivisioncode = Convert.ToInt32(rows["subdivisioncode"]),
                //        subdivisionname = Convert.ToString(rows["subdivisionname"]),
                //        divisionname = Convert.ToString(rows["divisionname"]),
                //    });
                //}
            }
            catch(Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult SaveSubDiv(Model_msubdivision subdiv)
        {
            try
            {
                if (Request.Form["Save"] == "Save")
                {
                    if (subdiv.subdivisionid == 0)
                    {
                        subdiv.createdby = 1;
                        subdiv.createddate = DateTime.Now;
                        subdiv.modifiedby = 1;
                        subdiv.modifieddate = DateTime.Now;
                        subdiv.active = true;
                        _db.Entry(subdiv).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (subdiv.subdivisionid > 0)
                        {
                            obj.usermessage = "Successfully Created Sub Division";
                        }
                    }
                }
                else if (Request.Form["Save"] == "Update")
                {
                    subdiv.modifiedby = 1;
                    subdiv.modifieddate = DateTime.Now;
                    subdiv.createdby = 1;
                    subdiv.createddate = DateTime.Now;
                    subdiv.active = true;
                    _db.Entry(subdiv).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    if (subdiv.subdivisionid > 0)
                    {
                        obj.usermessage = "Successfully Updated Sub Division";
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

        public ActionResult EditSubDiv(int id) 
        {
            DataTable divs = new DataTable();
            try
            {
                if (id > 0)
                {
                    var list = new Dictionary<string, object>();
                    list.Add("SubDivId", id);
                    divs = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetSubDivOnId", list);
                }
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            obj.resultData = divs;
            return Json(new { obj_subdivs = JsonConvert.SerializeObject(obj.resultData) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteSubDiv(int id)
        {
            try 
            {
                if(id > 0)
                {
                    var list = new Dictionary<string, object>();
                    list.Add("SubDivId", id);
                    sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_deleteSubDivOnId", list);
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