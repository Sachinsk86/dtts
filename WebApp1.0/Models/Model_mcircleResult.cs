using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
    public class Model_mcircleResult
    {
        [Key]
        public byte circleid { get; set; }
        public byte circlecode { get; set; }
        public string circlename { get; set; }
        public byte ref_zoneid { get; set; }
        public string zonename { get; set; }
       
    }
}