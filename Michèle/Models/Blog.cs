using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Michèle.Models
{
    public class Blog
    {
        public int BlogID { get; set; }
        public DateTime BlogDate { get; set; }
        public bool View { get; set; }
        public string MainPhoto { get; set; }
        public string[] Photos { get; set; }


    }
}