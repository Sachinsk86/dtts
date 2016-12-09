using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  [Table("msubdivision")]
  public class Model_msubdivision
  {
    [Key]
    public int subdivisionid { get; set; }
    public int subdivisioncode { get; set; }
    public string subdivisionname { get; set; }
    public int ref_divisionid { get; set; }
    public int createdby { get; set; }
    public DateTime? createddate { get; set; }
    public int? modifiedby { get; set; }
    public DateTime? modifieddate { get; set; }
    public bool active { get; set; }
  }
}