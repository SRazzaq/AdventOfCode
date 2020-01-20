using System.Drawing;

namespace Day03
{
    internal static class PointExtension
    {
        internal static Point Move(this Point location, char direction)
        {
            switch (direction)
            {
                case '^': location.Y--; break;
                case '<': location.X--; break;
                case '>': location.X++; break;
                case 'v': location.Y++; break;
            }

            return location;
        }
    }
}