using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Michèle.Models
{
    public class WorkLang
    {
        public int WorkLangID { get; set; }
        public int WorkID { get; set; }
        public string WorkName { get; set; }
        public string Describe { get; set; }
        public int LanguageID { get; set; }

        public Language Language { get; set; }
    }
}