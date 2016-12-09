using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  public class Model_TransformerSuppResult
  {
    public int locationid { get; set; }
    public string locationname { get; set; }
    public int transformerid { get; set; }
    public string Transformercode { get; set; }
    public string zonename { get; set; }
    public string circlename { get; set; }
    public string divisionname { get; set; }
    public string subdivisionname { get; set; }
    public string sectionname { get; set; }
    public string MakeOdDtr { get; set; }
    public int dtrcapacity { get; set; }
  }
}