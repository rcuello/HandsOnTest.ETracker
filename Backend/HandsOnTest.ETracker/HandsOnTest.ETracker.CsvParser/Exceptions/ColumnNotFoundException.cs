using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.ETracker.CsvParser.Exceptions
{
    public class ColumnNotFoundException : MalformedLineException
    {
        private long ordinal;
        public ColumnNotFoundException()
        {
        }

        public ColumnNotFoundException(string message, long lineNumber, long ordinal) : base(message, lineNumber)
        {
            this.ordinal = ordinal;
        }
    }
}
