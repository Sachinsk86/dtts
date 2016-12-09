using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
    public class Model_ExcelImport
    {
        [DisplayName("Location Name")]
        public string locationname { get; set; }
        public string Transformercode { get; set; }
        public string zonename { get; set; }
        public string circlename { get; set; }
        public string divisionname { get; set; }
        public string subdivisionname { get; set; }
        public string sectionname { get; set; }
        public string MakeOfDtr { get; set; }
        public int dtrcapacity { get; set; }
    }
}