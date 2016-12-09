using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebApi1._0.Models
{
  public class Transformer
  {
    public string username { get; set; }
    public string password { get; set; }
    public string transformerlabel { get; set; }
    public int transformerid { get; set; }
    public List<ImageDetails> imagedetail = new List<ImageDetails>();
    public class ImageDetails
    {
      public Bitmap imagename { get; set; }
      //string imagename { get; set; }
      public double imagelongitude { get; set; }
      public double imagelatitude { get; set; }
    }
  }
}