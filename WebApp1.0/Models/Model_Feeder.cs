using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
    [Table("mfeeder")]
    public class Model_Feeder
    {
        [Key]
        public int feederid { get; set;}
        public int feedercode { get; set; }
        public string feederuniquecode { get; set; }
        public int ref_feedertypeid { get; set; }
        public int ref_feedercategoryid { get; set; }
        public int ref_substationid { get; set; }
        public string feedername { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int? modifiedby { get; set; }
        public DateTime? modifieddate { get; set; }
        public bool active { get; set; }
    }
}