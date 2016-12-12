using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp1._0.Models;
using WebApp1._0.Security;
using WebApp1._0.sp;

namespace WebApp1._0.Controllers
{
  public class DashboardController : BaseController
  {
    private DBContext _db = new DBContext();
    private DBContext obj = new DBContext();

    // GET: Dashboard
    [CustomAuthorize(Roles = "Admin")]
    public ActionResult Index()
    {
      try
      {
        //string FullName = User.username;
        obj.obj_zone = _db.Zone.ToList();
      }
      catch(Exception ex)
      {
        Console.Write(ex.Message);
      }
      return View(obj);
    }

    [HttpPost]
    public ActionResult Index(Model_TransformerFilter filter)
    {
      DataTable dt = new DataTable();
      try
      {
        string where = null;
        if(filter.zone != 0)
        {
         where += "z.zoneid = " + filter.zone;
         obj.obj_location.ref_zoneid = filter.zone;
        }
        if(filter.circle != 0)
        {
         where += " AND ";
         where += "c.circleid = " + filter.circle;
         obj.obj_location.ref_circleid = filter.circle;
        }
        if (filter.division != 0)
        {
         where += " AND ";
         where += "d.divisionid = " +filter.division;
         obj.obj_location.ref_divisionid = filter.division;
        }
        if(filter.subdivision != 0)
        {
         where += " AND ";
         where += "sb.subdivisionid = " +filter.subdivision;
         obj.obj_location.ref_subdivisionid = filter.subdivision;
        }
        if(filter.section != 0)
        {
         where += " AND ";
         where += "sc.sectionid = " + filter.section;
         obj.obj_location.ref_sectionid = filter.section;
        }
        dt = sp.Sp_Generic_Class.GetMultipleRecordByStringParam("Sp_GetTransformerSearchFilterData", where);
        foreach (DataRow row in dt.Rows)
        {
          obj.importtoexcel.Add(new Model_ExcelImport
          {
            zonename = Convert.ToString(row["zonename"]),
            circlename = Convert.ToString(row["circlename"]),
            divisionname = Convert.ToString(row["divisionname"]),
            subdivisionname = Convert.ToString(row["subdivisionname"]),
            sectionname = Convert.ToString(row["sectionname"]),
            Transformercode = Convert.ToString(row["Transformercode"]),
            MakeOfDtr = Convert.ToString(row["MakeOfDtr"]),
            dtrcapacity = Convert.ToInt32(row["dtrcapacity"]),
            locationname = Convert.ToString(row["locationname"])
          });
        }
        //foreach (DataRow row in dt)
        //{
        //  obj.obj_transformerSuppCode.Add(new Model_TransformerSuppResult
        //  {
        //    transformerid = Convert.ToInt32(row["transformerid"]),
        //    zonename = Convert.ToString(row["zonename"]),
        //    circlename = Convert.ToString(row["circlename"]),
        //    divisionname = Convert.ToString(row["divisionname"]),
        //    subdivisionname = Convert.ToString(row["subdivisionname"]),
        //    sectionname = Convert.ToString(row["sectionname"]),
        //    Transformercode = Convert.ToString(row["Transformercode"]),
        //    MakeOdDtr = Convert.ToString(row["MakeOdDtr"]),
        //    dtrcapacity = Convert.ToInt32(row["dtrcapacity"])
        //  });
        //}
      }
      catch(Exception ex)
      {
       Console.Write(ex.Message);
      }
      Session["model"] = obj.importtoexcel;
      obj.resultData = dt;
      obj.obj_zone = _db.Zone.ToList();
      return View(obj);
    }

    public ActionResult GetCircle()
    {
      try
      {
        int zoneId = Convert.ToInt32(Request.Form["ZoneId"]);
        obj.obj_circle = _db.Circle.Where(d=>d.ref_zoneid == zoneId).ToList();
      }
      catch(Exception ex)
      {
        Console.Write(ex.Message);
      }
      return Json(new { obj_circle = obj.obj_circle }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult GetDivision()
    {
      try
      {
        int circleId = Convert.ToInt32(Request.Form["circleId"]);
        obj.obj_division = _db.Division.Where(d=>d.ref_circleid == circleId).ToList();
      }
      catch(Exception ex)
      {
        Console.Write(ex.Message);
      }
      return Json(new { obj_division = obj.obj_division }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult GetSubDivision()
    {
      try
      {
        int divisionId = Convert.ToInt32(Request.Form["divisionId"]);
        obj.obj_subdivision = _db.SubDivision.Where(d => d.ref_divisionid == divisionId).ToList();
      }
      catch(Exception ex)
      {
        Console.Write(ex.Message);
      }
      return Json(new { obj_subdivision = obj.obj_subdivision }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult GetSection()
    {
      try
      {
        int subdivisionId = Convert.ToInt32(Request.Form["subdivisionId"]);
        obj.obj_section = _db.Section.Where(d => d.ref_subdivisionid == subdivisionId).ToList();
      }
      catch (Exception ex)
      {
        Console.Write(ex.Message);
      }
      return Json(new { obj_section = obj.obj_section }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult GetTransformerSuppCode()
    {
      try
      {
        int sectionId = Convert.ToInt32(Request.Form["sectionId"]);
        obj.obj_transformerSuppCode = (from trsnfrmr in _db.Transformer
                             from supp in _db.Supplier
                             from locn in _db.Location 
                             where(trsnfrmr.ref_supplierid == supp.supplierid && trsnfrmr.ref_locationid == locn.locationid && locn.ref_sectionid == sectionId)
                             select new Model_TransformerSuppResult { transformerid = trsnfrmr.transformerid, Transformercode = supp.suppliercode+" "+trsnfrmr.manufactureserialno}
                            ).ToList();
      }
      catch (Exception ex)
      {
        Console.Write(ex.Message);
      }
      return Json(new { obj_transformerSuppCode = obj.obj_transformerSuppCode }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult GetImages()
    {
      int tId = Convert.ToInt32(Request.Form["TransformerId"]);
      try
      {
        if(tId != 0)
        {
          var list = new Dictionary<string, object>();
          list.Add("tId", tId);
          DataRowCollection userDet = sp.Sp_Generic_Class.GetMultipleRecordByParam("Sp_GetTransformerImage", list);
          foreach (DataRow img in userDet)
          {
            obj.images.Add(new Model_mtransformerimage {
              imagefilename = Convert.ToString(img["imagefilename"]),
              imagelatitude = Convert.ToDecimal(img["imagelatitude"]),
              imagelongitude = Convert.ToDecimal(img["imagelongitude"])
            });
          }
        }
      }
      catch(Exception ex)
      {
        Console.Write(ex.Message);
      }
      return Json(new {images = obj.images },JsonRequestBehavior.AllowGet);
    }

    public ActionResult ExportData()
    {
      GridView gv = new GridView();
      gv.DataSource = Session["model"];

      //gv.Columns(8).Visible = false;
      gv.DataBind();
      int i = gv.Rows.Count;
      if (i > 0)
      {
        gv.HeaderRow.Cells[0].Text = "Location";
        gv.HeaderRow.Cells[1].Text = "Transformer Code";
        gv.HeaderRow.Cells[2].Text = "Zone";
        gv.HeaderRow.Cells[3].Text = "Circle";
        gv.HeaderRow.Cells[4].Text = "Division";
        gv.HeaderRow.Cells[5].Text = "Sub Division";
        gv.HeaderRow.Cells[6].Text = "Section";
        gv.HeaderRow.Cells[7].Text = "Make of DTR";
        gv.HeaderRow.Cells[8].Text = "DTR Capacity";
      }
      Response.ClearContent();
      Response.Buffer = true;
      Response.AddHeader("content-disposition", "attachment; filename=TransformerDetails.xls");
      Response.ContentType = "application/ms-excel";
      Response.Charset = "";
      StringWriter sw = new StringWriter();
      HtmlTextWriter htw = new HtmlTextWriter(sw);
      gv.RenderControl(htw);
      Response.Output.Write(sw.ToString());
      Response.Flush();
      Response.End();
      return RedirectToAction("Index", "ExportToExcel");
    }

    

  }
}