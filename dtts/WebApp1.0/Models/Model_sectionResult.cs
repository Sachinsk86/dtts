using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
    public class Model_sectionResult
    {
        [Key]
        public int sectionid { get; set; }
        public int? sectioncode { get; set; }
        public string sectionname { get; set; }
        public int ref_subdivisionid { get; set; }
        public string subdivisionname { get; set; }
    }
}