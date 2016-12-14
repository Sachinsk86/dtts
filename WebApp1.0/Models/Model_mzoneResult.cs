using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
    public class Model_mzoneResult
    {
        [Key]
        public byte zoneid { get; set; }
        public byte zonecode { get; set; }
        public string zonename { get; set; }
        public byte ref_corporateid { get; set; }
        public string corporatename { get; set; }
    }
}