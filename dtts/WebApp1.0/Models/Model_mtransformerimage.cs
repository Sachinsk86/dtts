using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  [Table("mtransformerimage")]
  public class Model_mtransformerimage
  {
    [Key]
    public int transformerimageid { get; set; }
    public int ref_transformerid { get; set; }
    public string imagefilename { get; set; }
    public string imagefilepath { get; set; }
    public decimal imagelatitude { get; set; }
    public decimal imagelongitude { get; set; }
    public int createdby { get; set; }
    public DateTime createddate { get; set; }
    public int modifiedby { get; set; }
    public DateTime modifieddate { get; set; }
    public bool active { get; set; }
  }
}