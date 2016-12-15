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
    public class SchemeController : Controller
    {
        private DBContext _db = new DBContext();
        private DBContext obj = new DBContext();
        // GET: Scheme
        public ActionResult Index()
        {
            try
            {
                DataTable entity = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetSchemeResult");
                obj.resultData = entity;
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult SaveSchema(Model_mScheme scheme)
        {
            try
            {
                if (Request.Form["Save"] == "Save")
                {
                    if (scheme.schemeid == 0)
                    {
                        scheme.createdby = 1;
                        scheme.createddate = DateTime.Now;
                        scheme.active = true;
                        _db.Entry(scheme).State = System.Data.Entity.EntityState.Added;
                        _db.SaveChanges();
                        if (scheme.schemeid > 0)
                        {
                            obj.usermessage = "Successfully Created Section";
                        }
                    }
                }
                else if (Request.Form["Save"] == "Update")
                {
                    scheme.modifiedby = 1;
                    scheme.modifieddate = DateTime.Now;
                    scheme.createdby = 1;
                    scheme.createddate = DateTime.Now;
                    scheme.active = true;
                    _db.Entry(scheme).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    if (scheme.schemeid > 0)
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
        public ActionResult editScheme(int id)
        {
            DataTable scheme = new DataTable();
            try
            {
                if (id > 0)
                {
                    var list = new Dictionary<string, object>();
                    list.Add("schemeId", id);
                    scheme = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetSchemeOnId", list);
                }
            }
            catch (Exception ex)
            {
                obj.usermessage = ex.Message;
                Console.Write(ex.Message);
            }
            obj.resultData = scheme;
            return Json(new { obj_scheme = JsonConvert.SerializeObject(obj.resultData) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult deleteScheme(int id)
        {
            try
            {
                (from x in _db.scheme
                 where x.schemeid == id
                 select x).ToList().ForEach(xx => xx.active = false);
                _db.SaveChanges();
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