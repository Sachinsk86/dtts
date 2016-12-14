using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
    public class Model_mdivResult
    {
        [Key]
        public byte divisionid { get; set; }
        public byte divisioncode { get; set; }
        public string divisionname { get; set; }
        public byte ref_circleid { get; set; }
        public string circlename { get; set; }
    }
}