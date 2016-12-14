using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  [Table("mlocation")]
  public class Model_mlocation
  {
    [Key]
    public int locationid { get; set; }
    public string locationcode { get; set; }
    public string locationname { get; set; }
    public byte ref_zoneid { get; set; }
    public byte ref_circleid { get; set; }
    public int ref_divisionid { get; set; }
    public int ref_subdivisionid { get; set; }
    public int ref_sectionid { get; set; }
    public int createdby { get; set; }
    public int? modifiedby { get; set; }
    public DateTime? modifieddate { get; set; }
    public DateTime? createddate { get; set; }
    public bool active { get; set; }

  }
}