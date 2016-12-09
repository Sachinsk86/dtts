using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
    
    public class Model_musersView
    {
        [Key]
        public int userid { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public int ref_organizationid { get; set; }
        public string organizationname { get; set; }
        public int ref_roleid { get; set; }
        public string rolename { get; set; }
        public int ref_designationid { get; set; }
        public string designationname { get; set; }
        public string userlandlineno { get; set; }
        public string usermobileno { get; set; }
        public string useremailid { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int modifiedby { get; set; }
        public DateTime modifieddate { get; set; }


        internal void Add(Model_musersView model_musersView)
        {
            throw new NotImplementedException();
        }
    }
}