using HandsOnTest.ETracker.CsvParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.ETracker.CsvParser.Repository
{
    public interface IDealerTrackCsvReaderRepository
    {
        Task<IEnumerable<DealerTrackText>> ProcessFile(string contenido);
    }
}
