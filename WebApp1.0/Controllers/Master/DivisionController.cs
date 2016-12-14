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
    public class DivisionController : Controller
    {
        private DBContext _db = new DBContext();
        private DBContext obj = new DBContext();
        // GET: Division
        public ActionResult Index()
        {
            try
            {
                DataTable circle = sp.Sp_Generic_Class.GetMultipleRecord("Sp_getCircleDetails");
                obj.resultData = circle;

                DataTable divRes = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetDivisionsResult");
                obj.resultView = divRes;

                ////Mapper.CreateMap<User,UserDto >();  
                //foreach (DataRow row in circle)
                //{
                //    obj.obj_circlrResult.Add(new Model_mcircleResult
                //    {
                //        circleid = Convert.ToByte(row["circleid"]),
                //        circlename = Convert.ToString(row["circlename"]),
                //    });
                //}
                //foreach (DataRow div in divRes)
                //{
                //    obj.obj_divResult.Add(new Model_mdivResult
                //    {
                //        divisionid = Convert.ToByte(div["divisionid"]),
                //        divisioncode = Convert.ToByte(div["divisioncode"]),
                //        divisionname = Convert.ToString(div["divisionname"]),
                //        circlename = Convert.ToString(div["circlename"]),
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
        public ActionResult SaveDiv(Model_mdivision div)
        {
            try
            {
                if (Request.Form["Save"] == "Save")
                {
                    if (div.divisionid == 0)
                    {
                        div.createdby = 1;
                        div.createddate = DateTime.Now;
                        div.active = true;
                        _db.Entry(div).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (div.divisionid > 0)
                        {
                            obj.usermessage = "Successfully Created Division";
                        }
                    }
                }
                else if (Request.Form["Save"] == "Update")
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
            DataTable div = new DataTable();
            try
            {
                if (id > 0)
                {
                    var list = new Dictionary<string, object>();
                    list.Add("divId", id);
                    div = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetDivOnId", list);
                }
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }

            obj.resultData = div;
            return Json(new { obj_div = JsonConvert.SerializeObject(obj.resultData) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteDiv(int id)
        {
            try
            {
                if (id > 0)
                {
                    var list = new Dictionary<string, object>();
                    list.Add("divId", id);
                    sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_DeleteDivOnId", list);
                }
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return Json(new { },JsonRequestBehavior.AllowGet);
        }
    }
}