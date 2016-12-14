using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  
    public class Model_LocationResult
    {
        [Key]
        public int locationid { get; set; }
        public string locationcode { get; set; }
        public string locationname { get; set; }
        public byte ref_zoneid { get; set; }
        public byte ref_circleid { get; set; }
        public byte ref_divisionid { get; set; }
        public int ref_subdivisionid { get; set; }
        public int ref_sectionid { get; set; }
    }
}