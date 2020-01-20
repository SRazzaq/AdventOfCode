using System.Text.RegularExpressions;

namespace Day14
{
    internal class Reindeer
    {
        internal Reindeer(string line)
        {
            var m = Regex.Match(line, @"(.*) can fly (\d*) km/s for (\d*) seconds, but then must rest for (\d*) seconds.");
            
            Name = m.Groups[1].Value;
            
            Speed = int.Parse(m.Groups[2].Value);
            FlyTime = int.Parse(m.Groups[3].Value);
            RestTime = int.Parse(m.Groups[4].Value);
        }

        internal string Name { get; set; }
        internal int Speed { get; set; }
        internal int FlyTime { get; set; }
        internal int RestTime { get; set; }

        internal int DistanceTravelled(int time)
        {
            var fullIteration = time / (FlyTime + RestTime);
            var distance = fullIteration * Speed * FlyTime;

            var timeRemaining = time - (fullIteration * (FlyTime + RestTime));
            if (timeRemaining > FlyTime)
                distance += Speed * FlyTime;
            else
                distance += Speed * timeRemaining;

            return distance;
        }
    }
}