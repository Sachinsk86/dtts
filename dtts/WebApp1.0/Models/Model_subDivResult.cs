using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
    public class Model_subDivResult
    {
        [Key]
        public int subdivisionid { get; set; }
        public int subdivisioncode { get; set; }
        public string subdivisionname { get; set; }
        public int ref_divisionid { get; set; }
        public string divisionname { get; set; }
    }
}