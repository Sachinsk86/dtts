using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  [Table("muser")]
  public class Model_muser
  {
    [Key]
    public int userid { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string name { get; set; }
    public int ref_organizationid { get; set; }
    public int ref_roleid { get; set; }
    public int ref_designationid { get; set; }
    public string userlandlineno { get; set; }
    public string usermobileno { get; set; }
    public string useremailid { get; set; }
    public int createdby { get; set; }
    public DateTime createddate { get; set; }
    public int  modifiedby { get; set; }
    public DateTime modifieddate { get; set; }
    public bool active { get; set; }
  }
}