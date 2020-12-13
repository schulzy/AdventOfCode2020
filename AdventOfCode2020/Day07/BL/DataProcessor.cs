using System.Collections.Generic;
using System.IO;

namespace Day07.BL
{
    internal class DataProcessor
    {
        internal IEnumerable<string> GetData()
        {
            List<string> data = new List<string>();
            foreach (var line in File.ReadAllLines("Data07.txt"))
            {
                data.Add(line);
            }

            return data;
        }
    }
}
