using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  [Table("msupplier")]
  public class Model_msupplier
  {
    [Key]
    public int supplierid { get; set; }
    public string suppliercode { get; set; }
    public string suppliername { get; set; }
    public bool ismanufacturer { get; set; }
    public string supplieraddress { get; set; }
    public int ref_cityid { get; set; }
    public string postalcode { get; set; }
    public string supplierspoc { get; set; }
    public string supplierlandlineno { get; set; }
    public string suppliermobileno { get; set; }
    public string supplierfaxno { get; set; }
    public string supplieremailid { get; set; }
    public string remarks { get; set; }
    public int createdby { get; set; }
    public DateTime? createddate { get; set; }
    public int? modifiedby { get; set; }
    public DateTime? modifieddate { get; set; }
    public bool active { get; set; }
  }
}