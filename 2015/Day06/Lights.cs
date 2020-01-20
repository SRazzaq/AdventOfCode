namespace Day06
{
    internal class Lights
    {
        private int[,] lights = new int[1000, 1000];

        internal void Toggle(string inst)
        {
            var instruction = new Instruction(inst);
            for (var x = instruction.From.X; x <= instruction.To.X; x++)
            {
                for (var y = instruction.From.Y; y <= instruction.To.Y; y++)
                {
                    switch (instruction.Type)
                    {
                        case "turn on": lights[x, y] = 1; break;
                        case "turn off": lights[x, y] = 0; break;
                        case "toggle": lights[x, y] = lights[x, y] == 1 ? 0 : 1; break;
                    }
                }
            }
        }

        internal void Adjust(string inst)
        {
            var instruction = new Instruction(inst);
            for (var x = instruction.From.X; x <= instruction.To.X; x++)
            {
                for (var y = instruction.From.Y; y <= instruction.To.Y; y++)
                {
                    switch (instruction.Type)
                    {
                        case "turn on": lights[x, y]++; break;
                        case "turn off": if (lights[x, y] > 0) lights[x, y]--; break;
                        case "toggle": lights[x, y] += 2; break;
                    }
                }
            }
        }

        internal int Output
        {
            get
            {
                var output = 0;
                for (var x = 0; x < lights.GetLength(0); x++)
                {
                    for (var y = 0; y < lights.GetLength(1); y++)
                    {
                        output += lights[x, y];
                    }
                }
                return output;
            }
        }
    }
}