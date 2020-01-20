using System;

namespace Day18
{
    internal class Lights
    {
        private bool[,] lights;

        internal Lights(string input)
        {
            var lines = input.Split(Environment.NewLine);

            lights = new bool[lines[0].Length, lines.Length];
            for (var y = 0; y < lines.Length; y++)
            {
                for (var x = 0; x < lines[y].Length; x++)
                {
                    lights[x, y] = (lines[y][x] == '#');
                }
            }
        }

        internal bool CornersOn { get; set; }

        internal void Cycle()
        {
            var newLights = (bool[,])lights.Clone();
            for (var y = 0; y < lights.GetLength(1); y++)
            {
                for (var x = 0; x < lights.GetLength(0); x++)
                {
                    var neighbors = CountNeighbors(x, y);
                    newLights[x, y] = (lights[x, y] && (neighbors == 2 || neighbors == 3)) ||
                                      (!lights[x, y] && neighbors == 3);
                }
            }
            lights = newLights;
        }

        private int CountNeighbors(int x, int y)
        {
            return GetLight(x-1, y-1) + GetLight(x, y-1) + GetLight(x+1, y-1) +
                   GetLight(x-1,   y) +                    GetLight(x+1,   y) +
                   GetLight(x-1, y+1) + GetLight(x, y+1) + GetLight(x+1, y+1);
        }
        private int GetLight(int x, int y)
        {
            if (x < 0 || y < 0 || x > lights.GetLength(0) - 1 || y > lights.GetLength(1) - 1)
                return 0;
            else
            {
                if (CornersOn)
                {
                    if ((x == 0 && y == 0) ||
                        (x == 0 && y == lights.GetLength(1) - 1) ||
                        (x == lights.GetLength(0) - 1 && y == 0) ||
                        (x == lights.GetLength(0) - 1 && y == lights.GetLength(1) - 1))
                        return 1;
                }

                return (lights[x, y] ? 1 : 0);
            }
        }

        internal void TurnCornersOn()
        {
            lights[0, 0] =
            lights[0, lights.GetLength(1) - 1] =
            lights[lights.GetLength(0) - 1, 0] =
            lights[lights.GetLength(0) - 1, lights.GetLength(1) - 1] = true;
        }

        internal int Count()
        {
            var count = 0;
            for (var y = 0; y < lights.GetLength(1); y++)
            {
                for (var x = 0; x < lights.GetLength(0); x++)
                {
                    count += GetLight(x,y);
                }
            }
            return count;
        }
    }
}