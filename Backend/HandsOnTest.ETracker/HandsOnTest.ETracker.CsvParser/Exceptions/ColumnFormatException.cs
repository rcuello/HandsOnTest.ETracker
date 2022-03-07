using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.ETracker.CsvParser.Exceptions
{
    public class ColumnFormatException : MalformedLineException
    {
        private long ordinal;
        public ColumnFormatException()
        {
        }

        public ColumnFormatException(string message, long lineNumber, long ordinal) : base(message, lineNumber)
        {
            this.ordinal = ordinal;
        }

        public ColumnFormatException(string message, long lineNumber, long ordinal, string columnName) : base(message, lineNumber)
        {
            this.ordinal = ordinal;
            this.ColumnName = columnName;
        }

        public ColumnFormatException(string message, long lineNumber, long ordinal, string columnName, Exception exception) : base(message, lineNumber, exception)
        {
            this.ordinal = ordinal;
            this.ColumnName = columnName;
        }

        public string FullMessage
        {
            get
            {
                return $"line: {this.LineNumber} - column: [{this.ordinal}]{this.ColumnName}. Error: {this.Message}";
            }
        }
    }
}
