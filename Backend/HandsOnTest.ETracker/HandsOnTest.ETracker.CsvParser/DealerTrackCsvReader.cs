using HandsOnTest.ETracker.CsvParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.ETracker.CsvParser
{
    public class DealerTrackCsvReader
    {
        private readonly char Separator                 = ',';
        private readonly bool TrimWhiteSpace            = true;
        private readonly bool IgnoreBlankLines          = true;
        private readonly bool HasFieldsEnclosedInQuotes = true;
        private readonly bool IgnoreFirstLine           = true;

        public async Task<IEnumerable<DealerTrackText>> ParseContent(string fileContent)
        {
            if(string.IsNullOrEmpty(fileContent)) return Enumerable.Empty<DealerTrackText>();

            var dealerTrackCollection = new List<DealerTrackText>();

            var trimStartContent = fileContent.TrimStart();

            //Read the file
            using (TextReader reader = new StringReader(trimStartContent))
            {
                using (var parser = CreateParser(reader))
                {
                    while (!parser.EndOfFile)
                    {
                        TextFields fields = parser.ReadFields();

                        var dealerTrackRow = fields?.To<DealerTrackText>();

                        if(dealerTrackRow!=null) dealerTrackCollection.Add(dealerTrackRow);

                    }
                }
            }
            await Task.CompletedTask;

            return dealerTrackCollection;
        }

        private DelimitedFieldParser CreateParser(TextReader reader)
        {
            var parser = new DelimitedFieldParser(reader);

            parser.SetDelimiters(Separator);
            parser.TrimWhiteSpace               = TrimWhiteSpace;
            parser.IgnoreBlankLines             = IgnoreBlankLines;
            parser.HasFieldsEnclosedInQuotes    = HasFieldsEnclosedInQuotes;
            parser.IgnoreFirstLine              = IgnoreFirstLine;
            return parser;
        }
    }
}
