using System.Collections.Generic;
using System.IO;

namespace Day08.BL
{
    internal class DataProcessor
    {
        internal IEnumerable<string> GetData()
        {
            List<string> data = new List<string>();
            foreach (var line in File.ReadAllLines("Data08.txt"))
            {
                data.Add(line);
            }

            return data;
        }
    }
}
