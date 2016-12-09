using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
    [Table("mcorporate")]
    public class Model_mcorporate
    {
        [Key]
        public int corporateid { get; set; }
        public int corporatecode { get; set; }
        public string corporatename { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int modifiedby { get; set; }
        public DateTime modifieddate { get; set; }
        public bool active { get; set; }
    }
}