using System;
using System.Collections.Generic;

namespace Day14
{
    internal class Reindeers : List<Reindeer>
    {
        public Reindeers(string input)
        {
            var lines = input.Split(Environment.NewLine);

            foreach (var line in lines)
            {
                var reindeer = new Reindeer(line);
                this.Add(reindeer);
            }
        }
    }
}