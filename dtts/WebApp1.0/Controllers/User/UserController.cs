using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1._0.Models;

namespace WebApp1._0.Controllers.User
{
  public class UserController : Controller
  {
    private DBContext _db = new DBContext();
    private DBContext obj = new DBContext();

    // GET: User
    public ActionResult Index()
    {
      DataRowCollection zone = sp.Sp_Generic_Class.GetMultipleRecord("Sp_getZones");
      DataRowCollection designation = sp.Sp_Generic_Class.GetMultipleRecord("Sp_getDesignation");
      DataRowCollection userDetails = sp.Sp_Generic_Class.GetMultipleRecord("Sp_GetUsersDetail");

      //zone data
      foreach (DataRow row in zone)
      {
        obj.obj_zone.Add(new Model_mzone
        {
          zoneid = Convert.ToInt32(row["zoneid"]),
          zonename = Convert.ToString(row["zonename"]),
        });
      }
      //Designation data
      foreach (DataRow design in designation)
      {
        obj.obj_designation.Add(new Model_mdesignation
        {
          designationid = Convert.ToInt32(design["designationid"]),
          designationname = Convert.ToString(design["designationname"]),
        });
      }
      //Users Data
      foreach (DataRow uDetails in userDetails)
      {
        obj.obj_userView.Add(new Model_musersView
        {
          userid = Convert.ToInt32(uDetails["userid"]),
          username = Convert.ToString(uDetails["username"]),
          organizationname = Convert.ToString(uDetails["organizationname"]),
          designationname = Convert.ToString(uDetails["designationname"]),
          useremailid = Convert.ToString(uDetails["useremailid"]),
        });
      }
      return View(obj);
    }

    [HttpPost]
    public ActionResult Index(Model_muser u) // User save method
    {
      try
      {
        if (Request.Form["Submit"] == "Create User")
        {
          if (u.userid == 0)
          {
            //u.ref_designationid = 1;
            //u.ref_organizationid = 1;
            // u.userlandlineno = "1234567891";
            u.modifiedby = 1;
            u.modifieddate = DateTime.Now;
            u.createdby = 1;
            u.createddate = DateTime.Now;
            u.active = true;
            _db.Entry(u).State = System.Data.Entity.EntityState.Added;
            _db.SaveChanges();
            if (u.userid > 0)
            {
              obj.usermessage = "Successfully Created User Details";
            }
          }
        }
        else if (Request.Form["Update"] == "Update User")
        {
          u.modifiedby = 1;
          u.modifieddate = DateTime.Now;
          u.createdby = 1;
          u.createddate = DateTime.Now;
          u.active = true;
          _db.Entry(u).State = System.Data.Entity.EntityState.Modified;
          _db.SaveChanges();
          if (u.userid > 0)
          {
            obj.usermessage = "Successfully Updated User Details";
          }
        }

      }
      catch (Exception ex)
      {
        obj.usermessage = ex.Message;
        Console.Write(ex.Message);
      }
      return View(obj);
    }
    public ActionResult getUsersOnId(int id)
    {
      try
      {
        var list = new Dictionary<string, object>();
        list.Add("userId", id);
        DataRowCollection userDet = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetUserDetailsOnId", list);
        foreach (DataRow rows in userDet)
        {
          obj.obj_userView.Add(new Model_musersView
          {
            userid = Convert.ToInt32(rows["userid"]),
            username = Convert.ToString(rows["username"]),
            name = Convert.ToString(rows["name"]),
            ref_organizationid = Convert.ToInt32(rows["ref_organizationid"]),
            organizationname = Convert.ToString(rows["organizationname"]),
            ref_roleid = Convert.ToInt32(rows["ref_roleid"]),
            rolename = Convert.ToString(rows["rolename"]),
            ref_designationid = Convert.ToInt32(rows["ref_designationid"]),
            designationname = Convert.ToString(rows["designationname"]),
            userlandlineno = Convert.ToString(rows["userlandlineno"]),
            usermobileno = Convert.ToString(rows["usermobileno"]),
            useremailid = Convert.ToString(rows["useremailid"]),

          });
        }
      }
      catch (Exception ex)
      {
        Console.Write(ex.Message);
      }
      return Json(new { obj_user = obj.obj_userView }, JsonRequestBehavior.AllowGet);
    }
    public ActionResult DeleteUsers(int id)
    {
      var list = new Dictionary<string, object>();
      list.Add("userId", id);
      DataRowCollection delUser = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_DeleteUsersOnId", list);
      return Json(new { obj_delUser = delUser }, JsonRequestBehavior.AllowGet);
    }
  }
}