using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1._0.Models;

namespace WebApp1._0.Controllers.Master
{
    public class DivisionController : Controller
    {
        private DBContext _db = new DBContext();
        private DBContext obj = new DBContext();
        // GET: Division
        public ActionResult Index()
        {
            DataRowCollection circle = sp.Sp_Generic_Class.GetMultipleRecord("Sp_getCircleDetails");
            DataRowCollection divRes = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetDivisionsResult");
              //Mapper.CreateMap<User,UserDto >();  
            foreach (DataRow row in circle)
            {
                obj.obj_circlrResult.Add(new Model_mcircleResult 
                {
                    circleid = Convert.ToInt32(row["circleid"]),
                    circlename = Convert.ToString(row["circlename"]),
                });
            }
            foreach (DataRow div in divRes)
            {
                obj.obj_divResult.Add(new Model_mdivResult 
                { 
                    divisionid = Convert.ToInt32(div["divisionid"]),
                    divisioncode = Convert.ToInt32(div["divisioncode"]),
                    divisionname = Convert.ToString(div["divisionname"]),
                    circlename = Convert.ToString(div["circlename"]),
                });
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult SaveDiv(Model_mdivision div)
        {
            try
            {
                if(Request.Form["Submit"] == "Submit")
                {
                    if (div.divisionid == 0)
                    {
                        div.createdby = 1;
                        div.createddate = DateTime.Now;
                        div.modifiedby = 1;
                        div.modifieddate = DateTime.Now;
                        div.active = true;
                        _db.Entry(div).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (div.divisionid > 0)
                        {
                            obj.usermessage = "Successfully Created Division";
                        }
                    }
                }
                else if (Request.Form["Submit"] == "Update")
                {
                    div.modifiedby = 1;
                    div.modifieddate = DateTime.Now;
                    div.createdby = 1;
                    div.createddate = DateTime.Now;
                    div.active = true;
                    _db.Entry(div).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    if (div.divisionid > 0)
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

        public ActionResult EditDivision(int id) 
        {
            var list = new Dictionary<string, object>();
            list.Add("divId", id);
            DataRowCollection div = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetDivOnId", list);
            foreach (DataRow divs in div)
            {
                obj.obj_division.Add(new Model_mdivision 
                {
                    divisionid = Convert.ToInt32(divs["divisionid"]),
                    divisioncode = Convert.ToInt32(divs["divisioncode"]),
                    divisionname = Convert.ToString(divs["divisionname"]),
                    ref_circleid = Convert.ToInt32(divs["ref_circleid"]),
                });
            }
            return Json(new { obj_div = obj.obj_division }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteDiv(int id)
        {
            var list = new Dictionary<string, object>();
            list.Add("divId", id);
            sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_DeleteDivOnId", list);
            return Json(new { },JsonRequestBehavior.AllowGet);
        }
    }
}