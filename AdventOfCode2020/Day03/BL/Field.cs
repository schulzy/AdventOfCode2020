using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03.BL
{
    internal class Field
    {
        private List<List<Artifact>> _field = new List<List<Artifact>>();

        protected int Width
        {
            get
            {
                return _field.FirstOrDefault().Count;
            }
        }

        public int Height
        {
            get
            {
                return _field.Count;
            }
        }

        public Artifact GetElement(int x, int y)
        {
            if (y > Height)
                throw new IndexOutOfRangeException("Y coordinate is not valid");

            int tempX = x % Width;
            return _field[y][tempX];
        }

        public void AddNewSegment(string segment)
        {
            List<Artifact> artifacts = new List<Artifact>();
            foreach (var item in segment)
            {
                switch (item)
                {
                    case '.':
                        artifacts.Add(Artifact.Sqsquare);
                        break;
                    case '#':
                        artifacts.Add(Artifact.Tree);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"{item} unknown element.");
                }
            }
            _field.Add(artifacts);
        }
    }
}
