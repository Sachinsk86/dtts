using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi1._0.Models;

namespace WebApi1._0
{
  [Route("api/[controller]")]
  public class ImageReaderController : ApiController
  {
    // GET api/<controller>
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/<controller>/5
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<controller>
    public HttpResponseMessage Post(HttpRequestMessage Request, Transformer trans)
    {
      int TransformerId = trans.transformerid;
      string UserName = trans.username;
      Int32 UID = 0;
      string DTCNO = null, Message = null;
      if (TransformerId != 0 && trans.imagedetail != null)
      {
        try
        {
          string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
          SqlConnection conn = new SqlConnection(connstring);
          conn.Open();
          string query1 = "Select dtcnumber from mtransformer where transformerid='" + TransformerId + "'";
          SqlCommand npcmd = new SqlCommand(string.Format(query1), conn);
          DTCNO = Convert.ToString(npcmd.ExecuteScalar());
          conn.Close();
          if (DTCNO != "null")
          {
            conn.Open();
            string query2 = "Select userid from muser where username='" + UserName + "'";
            SqlCommand npcmd2 = new SqlCommand(string.Format(query2), conn);
            UID = Convert.ToInt32(npcmd2.ExecuteScalar());
            conn.Close();
            if (UID > 0)
            {
              int i = 0;
              for (i = 0; i < trans.imagedetail.Count; i++)
              {

                Bitmap localImg = new Bitmap(@"C:\Users\Sudhakar\Desktop\images.png");
                // string file =(@"C:\Users\Sudhakar\Desktop\images.png");
                trans.imagedetail[i].imagename = localImg;
                Image Imagefile = trans.imagedetail[i].imagename;
                string FileName = DTCNO.Trim() + "_" + i + ".png";
                string docpath = ConfigurationManager.AppSettings["docpath"].ToString();
                string folderPath = System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["docpath"].ToString()) + "/";
                Imagefile.Save(folderPath + FileName, System.Drawing.Imaging.ImageFormat.Png);
                decimal Latitude = Convert.ToDecimal(trans.imagedetail[i].imagelatitude);
                decimal Longitude = Convert.ToDecimal(trans.imagedetail[i].imagelongitude);
                conn.Open();
                string Query2 = "INSERT INTO mtransformerimage( ref_transformerid, imagefilename,imagefilepath,imagelatitude,imagelongitude,createdby) VALUES ('" + TransformerId + "','" + FileName + "','" + folderPath + "','" + Latitude + "','" + Longitude + "','" + UID + "')";
                SqlCommand npcmd3 = new SqlCommand(string.Format(Query2), conn);
                SqlDataReader npreader = npcmd3.ExecuteReader();
                conn.Close();
              }

              Message = ("Image Successfully store");
              return Request.CreateResponse(HttpStatusCode.OK, Message);
            }
            else
            {
              Message = ("Image is not store");
              return Request.CreateResponse(HttpStatusCode.BadRequest, Message);
            }
          }
          else
          {
            Message = ("DTC number is not available");
            return Request.CreateResponse(HttpStatusCode.BadRequest, Message);
          }
        }
        catch (SqlException e)
        {
          Message = ("Null value is not accepteable");
          return Request.CreateResponse(HttpStatusCode.BadRequest, Message);
        }
      }
      else
      {
        //ImageDetails = "Null value is not accepteable";
        // Message = "Null value is not accepteable";
        Message = ("Null value is not accepteable");
        return Request.CreateResponse(HttpStatusCode.BadRequest, Message);
      }


    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
    }
  }
}