using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Michèle.Models
{
    public class Work
    {
        public int WorkID { get; set; }
        public string MainPhoto { get; set; }       
        public int[] CategoryID { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual Slider Slider { get; set; }

    }
}