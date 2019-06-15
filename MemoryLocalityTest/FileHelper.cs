using System.IO;
using System.Linq;

namespace MemoryLocalityTest
{
    internal static class FileHelper
    {
        public static int[] LoadFilteredHistoricalData(string fname)
        {
            if (!File.Exists(fname))
            {
                return new int[0];
            }

            const double maxDeviationFromMin = 0.1;
            var allEntries = File.ReadAllLines(fname).Select(s => int.Parse(s)).ToArray();
            var min = allEntries.Min();
            return allEntries.Where(x => x <= (1 + maxDeviationFromMin) * min).ToArray();
        }
    }
}
