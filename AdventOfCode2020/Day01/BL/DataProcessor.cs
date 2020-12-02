using System;
using System.Collections.Generic;
using System.IO;

namespace Day01.BL
{
    class DataProcessor
    {
        internal IEnumerable<int> GetData()
        {
            List<int> data = new List<int>();
            foreach (var line in File.ReadAllLines("Data.txt"))
            {
                data.Add(Convert.ToInt32(line));
            }

            return data;
        }
    }
}
