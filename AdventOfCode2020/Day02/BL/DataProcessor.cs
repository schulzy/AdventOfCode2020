﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day02.BL
{
    class DataProcessor
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