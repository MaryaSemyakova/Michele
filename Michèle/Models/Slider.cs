using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Michèle.Models
{
    public class Slider
    {
        public int SliderID { get; set; }
        public string SliderPCUrl { get; set; }
        public string SlideTouchPadrUrl { get; set; }
        public string SlidePhoneUrl { get; set; }
        public int WorkID { get; set; }
    }
}