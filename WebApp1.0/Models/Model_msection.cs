using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  [Table("msection")]
  public class Model_msection
  {
    [Key]
    public int sectionid { get; set; }
    public int? sectioncode { get; set; }
    public string sectionname { get; set; }
    public int ref_subdivisionid { get; set; }
    public int createdby { get; set; }
    public int? modifiedby { get; set; }
    public DateTime? modifieddate { get; set; }
    public DateTime? createddate { get; set; }
    public bool active { get; set; }
  }
}