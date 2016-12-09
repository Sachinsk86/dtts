using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using WebApp1._0.Models;

namespace WebApp1._0.Controllers
{
    public class ImageReaderController : ApiController
    {
      private DBContext _db = new DBContext();

      [HttpPost]
      public HttpResponseMessage Post(HttpRequestMessage Request, Transformer trans)
      {
        string Message = null;
        string SaveLocation = null;
        try
        {
          for (int i = 0; i < trans.imagedetail.Count(); i++)
          {
            if (trans.imagedetail[i] != null)
             {
               byte[] DecodeInage = System.Convert.FromBase64String(trans.imagedetail[i].imagename);
               MemoryStream ms = new MemoryStream(DecodeInage, 0, DecodeInage.Length);
               ms.Write(DecodeInage, 0, DecodeInage.Length);
               System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
               string FileName = "1" + ".Png";
               //folderPath = System.Web.HttpContext.Current.Server.MapPath("~/Image");
               //string docpath = ConfigurationManager.AppSettings["docpath"].ToString();
               //SaveLocation = Server.MapPath("tmp") + "\\" + filename + "_GUID_" + Guid.NewGuid().ToString() + extension;
               //UserPicPath[i].SaveAs(SaveLocation);
               //string folderPath = System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["docpath"].ToString()) + "/";
               //var rootPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Images");
               var rootPath = System.Web.HttpContext.Current.Server.MapPath("~/Images");
               if (!Directory.Exists(rootPath))
               {
                 Directory.CreateDirectory(rootPath);
               }
               string DBImage = Path.Combine("~/Images", FileName);
               image.Save(rootPath + "\\" + FileName, System.Drawing.Imaging.ImageFormat.Png);
             }
          }
        }
        catch(Exception ex)
        {
          Message = ex.Message;
        }
        return Request.CreateResponse(HttpStatusCode.BadRequest, Message);
      }

    }
}
