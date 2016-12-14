﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  [Table("mcircle")]
  public class Model_mcircle
  {
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public byte circleid { get; set; }
    public byte circlecode { get; set; }
    public string circlename { get; set; }
    public byte ref_zoneid { get; set; }
    public int createdby { get; set; }
    public DateTime createddate { get; set; }
    public int? modifiedby { get; set; }
    public DateTime? modifieddate { get; set; }
    public bool active { get; set; }
  }
}