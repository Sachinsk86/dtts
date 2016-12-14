using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
    [Table("mdesignation")]
    public class Model_mdesignation
    {
        [Key]
        public int designationid {get;set;}
        public string designationcode {get;set;}
        public string designationname {get;set;}
        public int createdby {get;set;}
        public DateTime creatatedde {get;set;}
        public int? modifiedby {get;set;}
        public DateTime? modifieddate {get;set;}
        public bool active {get;set;}

    }
}