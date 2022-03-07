using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HandsOnTest.ETracker.CsvParser
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TextFieldAttribute : Attribute
    {
        public int Position { get; set; }
        public bool Required { get; set; }
        public string Separator { get; set; }
        public string Format { get; set; }
        public RegexOptions PatternOptions { get; }
        public string Pattern { get; set; }
        public string IgnoreRequiredOnDocumentTypes { get; set; }
        public string RequiredOnDocumentTypes { get; set; }
        public TextFieldAttribute(int position, bool required = true, string format = null, string separator = null, string pattern = null)
        {
            this.Position       = position;
            this.Required       = required;
            this.Format         = format;
            this.Separator      = separator;
            this.PatternOptions = RegexOptions.None;
            this.Pattern        = pattern;
        }
    }
}
