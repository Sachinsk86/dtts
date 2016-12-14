using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  [Table("mzone")]
  public class Model_mzone
  {
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public byte zoneid { get; set; }
    public byte zonecode { get; set; }
    public string zonename { get; set; }
    public byte ref_corporateid { get; set; }
    public int createdby { get; set; }
    public DateTime createddate  { get; set; }
    public int? modifiedby { get; set; }
    public DateTime? modifieddate { get; set; }
    public bool active { get; set; }
  }
}