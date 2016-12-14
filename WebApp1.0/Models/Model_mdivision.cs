using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  [Table("mdivision")]
  public class Model_mdivision
  {
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public byte divisionid { get; set; }
    public byte divisioncode { get; set; }
    public string divisionname { get; set; }
    public byte ref_circleid { get; set; }
    public int createdby { get; set; }
    public DateTime createddate { get; set; }
    public int? modifiedby { get; set; }
    public DateTime? modifieddate { get; set; }
    public bool active { get; set; }
  }
}