﻿using System.Collections.Generic;
using System.IO;

namespace Day03.BL
{
    internal class DataProcessor
    {
        internal IEnumerable<string> GetData()
        {
            List<string> data = new List<string>();
            foreach (var line in File.ReadAllLines("Data.txt"))
            {
                data.Add(line);
            }

            return data;
        }
    }
}
