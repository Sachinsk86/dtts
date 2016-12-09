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
            DataRowCollection divs = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetDivisionsResult");
            DataRowCollection subDiv = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetSubDivResult");
            foreach (DataRow row in divs)
            {
                obj.obj_divResult.Add(new Model_mdivResult
                {
                    divisionid = Convert.ToInt32(row["divisionid"]),
                    divisionname = Convert.ToString(row["divisionname"]),
                });
            }
            foreach (DataRow rows in subDiv)
            {
                obj.obj_subdivResult.Add(new Model_subDivResult 
                {
                    subdivisionid = Convert.ToInt32(rows["subdivisionid"]),
                    subdivisioncode = Convert.ToInt32(rows["subdivisioncode"]),
                    subdivisionname = Convert.ToString(rows["subdivisionname"]),
                    divisionname = Convert.ToString(rows["divisionname"]),
                });
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult SaveSubDiv(Model_msubdivision subdiv)
        {
            try
            {
                if (Request.Form["Submit"] == "Submit")
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
                }else if(Request.Form["Submit"] == "Update")
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
            var list = new Dictionary<string, object>();
            list.Add("SubDivId", id);
            DataRowCollection divs = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetSubDivOnId", list);
            foreach(DataRow subdiv in divs)
            {
                obj.obj_subdivision.Add(new Model_msubdivision 
                {
                    subdivisionid = Convert.ToInt32(subdiv["subdivisionid"]),
                    subdivisioncode = Convert.ToInt32(subdiv["subdivisioncode"]),
                    subdivisionname = Convert.ToString(subdiv["subdivisionname"]),
                    ref_divisionid = Convert.ToInt32(subdiv["ref_divisionid"]),
                });
            }
            return Json(new { obj_sdiv = obj.obj_subdivision }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteSubDiv(int id)
        {
            var list = new Dictionary<string, object>();
            list.Add("SubDivId", id);
            sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_deleteSubDivOnId", list);
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}