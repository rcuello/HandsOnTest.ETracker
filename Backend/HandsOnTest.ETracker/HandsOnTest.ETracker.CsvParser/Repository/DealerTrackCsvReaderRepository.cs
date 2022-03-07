using HandsOnTest.ETracker.CsvParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.ETracker.CsvParser.Repository
{
    public class DealerTrackCsvReaderRepository : IDealerTrackCsvReaderRepository
    {
        public async Task<IEnumerable<DealerTrackText>> ProcessFile(string contenido)
        {
            var reader      = new DealerTrackCsvReader();
            var collection  = await reader.ParseContent(contenido);

            return collection;
        }
    }
}
