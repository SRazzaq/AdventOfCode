using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Day13
{
    internal class Maze
    {
        private int number;

        public Maze(int number)
        {
            this.number = number;
        }

        public override string ToString()
        {
            var s = new StringBuilder();

            s.AppendLine("  0123456789");
            for (int y = 0; y < 7; y++)
            {
                s.Append($"{y} ");
                for (int x = 0; x < 10; x++)
                {
                    s.Append(IsValid(new Point(x, y)) ? "." : "#");
                }
                s.AppendLine();
            }

            return s.ToString();
        }

        internal int BFS(Point end)
        {
            var queue = new Queue<(int, Point)>();
            queue.Enqueue((0, new Point(1, 1)));

            var visited = new HashSet<Point>();
            
            while (queue.Count > 0)
            {
                var (step, loc) = queue.Dequeue();
                
                if (loc == end) return step;
                if (visited.Contains(loc)) continue;
                if (!IsValid(loc)) continue;

                visited.Add(loc);

                queue.Enqueue((step + 1, new Point(loc.X + 1, loc.Y)));
                queue.Enqueue((step + 1, new Point(loc.X - 1, loc.Y)));
                queue.Enqueue((step + 1, new Point(loc.X, loc.Y + 1)));
                queue.Enqueue((step + 1, new Point(loc.X, loc.Y - 1)));
            }

            return -1;
        }

        internal int Reachable(int iteration)
        {
            var queue = new Queue<(int, Point)>();
            queue.Enqueue((0, new Point(1, 1)));

            var visited = new HashSet<Point>();

            while (queue.Count > 0)
            {
                var (step, loc) = queue.Dequeue();

                if (step > iteration) continue;
                if (visited.Contains(loc)) continue;
                if (!IsValid(loc)) continue;

                visited.Add(loc);

                queue.Enqueue((step + 1, new Point(loc.X + 1, loc.Y)));
                queue.Enqueue((step + 1, new Point(loc.X - 1, loc.Y)));
                queue.Enqueue((step + 1, new Point(loc.X, loc.Y + 1)));
                queue.Enqueue((step + 1, new Point(loc.X, loc.Y - 1)));
            }

            return visited.Count;
        }

        private bool IsValid(Point p)
        {
            if (p.X < 0 || p.Y < 0) return false;

            int count = 0;
            var n = p.X*p.X + 3*p.X + 2*p.X*p.Y + p.Y + p.Y*p.Y + number;
            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count % 2 == 0;
        }
    }
}