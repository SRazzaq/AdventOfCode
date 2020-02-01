using System.Collections.Generic;

namespace Day10
{
    internal class Container
    {
        public Container()
        {
            Chips = new List<int>();
        }

        internal List<int> Chips { get; private set; }

        internal Container Low { get; set; }

        internal Container High { get; set; }
    }
}