using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  [Table("mtransformer")]
  public class Model_mtransformer
  {
    [Key]
    public int transformerid { get; set; }
    public string dtcnumber { get; set; }
    public string manufactureserialno { get; set; }
    public int ref_locationid { get; set; }
    public int ref_supplierid { get; set; }
    public int ref_powerratingid { get; set; }
    public int ref_voltageratingid { get; set; }
    public int ref_vectorgroupid { get; set; }
    public int guaranteeperiod { get; set; }
    public int frequency { get; set; }
    public int oilquantity { get; set; }
    public int radiatorbank { get; set; }
    public int coolingfan { get; set; }
    public int coolingpump { get; set; }
    public int spaceheater { get; set; }
    public DateTime testingdate { get; set; }
    public string yearofmanufacture { get; set; }
    public bool hasnameplate { get; set; }
    public string transformerlabel { get; set; }
    public decimal transformercost { get; set; }
    public int createdby { get; set; }
    public DateTime createddate { get; set; }
    public int? modifiedby { get; set; }
    public DateTime? modifieddate { get; set; }
    public bool active { get; set; } 
  }
}