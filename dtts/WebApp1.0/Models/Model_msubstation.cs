using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  [Table("msubstation")]
  public class Model_msubstation
  {
    [Key]
    public int substationid { get; set; }
    public int substationcode { get; set; }
    public string substationname { get; set; }
    public int ref_organizationid { get; set; }
    public int ref_stationcapacityid { get; set; }
    public int createdby { get; set; }
    public DateTime createddate { get; set; }
    public int modifiedby { get; set; }
    public DateTime modifieddate { get; set; }
    public bool active { get; set; }
  }
}