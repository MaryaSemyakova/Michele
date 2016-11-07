using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Michèle.Models
{
    public class BlogLang
    {
        public int BlogLangID { get; set; }
        public int BlogID { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public int LanguageID { get; set; }

        public Language Language { get; set; }
    }
}