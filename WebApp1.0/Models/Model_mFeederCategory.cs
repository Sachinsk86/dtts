using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
    [Table("mFeederCategory")]
    public class Model_mFeederCategory
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int feedercategoryid { get; set; }
        public string feedervcategoryname { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int modifiedby { get; set; }
        public DateTime modifieddate { get; set; }
        public bool active { get; set; }
    }
}