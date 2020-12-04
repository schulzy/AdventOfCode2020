using System;
using System.Collections.Generic;
using System.Text;

namespace Day03.BL
{
    internal class FieldManager
    {
        private Field _field;
        public FieldManager()
        {
            var data = new DataProcessor().GetData();
            _field = new Field();
            foreach (var item in data)
            {
                _field.AddNewSegment(item);
            }
        }

        public Dictionary<Artifact, long> GetArtifacts(int xdiff, int ydiff)
        {
            int startX = 0, startY = 0;
            Dictionary<Artifact, long> result = new Dictionary<Artifact, long>();
            int x = 0, y = 0; 
            for (int i = 1; i < _field.Height; i++)
            {
                if (startY + (ydiff * i) >= _field.Height)
                    break;

                var artifact = _field.GetElement(startX + (i * xdiff), startY + (ydiff * i));
                if (result.ContainsKey(artifact))
                    result[artifact]++;
                else
                    result.Add(artifact, 1);
            }
            return result;
        }
    }


}
