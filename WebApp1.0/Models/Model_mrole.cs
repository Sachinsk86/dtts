using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  [Table("mrole")]
  public class Model_mrole
  {
    [Key]
    public int roleid { get; set; }
    public string rolecode { get; set; }
    public string rolename { get; set; }
    public string description { get; set; }
    public int createdby { get; set; }
    public DateTime createddate { get; set; }
    public int modifiedby { get; set; }
    public DateTime modifieddate { get; set; }
    public bool active { get; set; }
  }
}