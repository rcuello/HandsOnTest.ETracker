using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.ETracker.CsvParser.Exceptions
{
    public class DataRequiredException : MalformedLineException
    {
        private long ordinal;
        public long ColumnNumber
        {
            get
            {
                return this.ordinal;
            }
        }
        public DataRequiredException()
        {
        }

        public DataRequiredException(string message, long lineNumber, long ordinal) : base(message, lineNumber)
        {
            this.ordinal = ordinal;
        }

        public string FullMessage
        {
            get
            {
                return $"line: {this.LineNumber} - column: {this.ColumnNumber}. Error: {this.Message}";
            }
        }
    }
}
