using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Michèle.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public string PhotoUrl { get; set; }
        public string PinterestUrl { get; set; }
        public string VkUrl { get; set; }
        public string BehanceUrl { get; set; }
        public int WorkID { get; set; }
    }
}