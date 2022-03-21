using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test2.Models
{
    public class empolyee
    {
        public int id { get; set; }
        public string name { get; set; }
        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string email { get; set; }
        public string address { get; set; }
        public string father_name { get; set; }
    }
}