using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.ETracker.CsvParser.Model
{
    public class DealerTrackText
    {
        [TextField(position: 0)] public String DealNumber { get; private set; }
        [TextField(position: 1)] public String CustomerName { get; private set; }
        [TextField(position: 2)] public String DealershipName { get; private set; }
        [TextField(position: 3)] public String Vehicle { get; private set; }
        [TextField(position: 4)] public String Price { get; private set; }
        [TextField(position: 5)] public String Date { get; private set; }
    }
}
