using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
    [Table("mDtrCapacity")]
    public class Model_mDtrCapacity
    {
        [Key]
        public int dtrcapacityid { get; set; }
        public string dtrcapacity { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int? modifiedby { get; set; }
        public DateTime? modifieddate { get; set; }
        public bool active { get; set; }

    }
}