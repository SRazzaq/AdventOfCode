using System;
using System.Collections.Generic;

namespace Day16
{
    internal class Aunts : List<Aunt>
    {
        public Aunts(string input)
        {
            var lines = input.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                this.Add(new Aunt(line));
            }
        }
    }
}