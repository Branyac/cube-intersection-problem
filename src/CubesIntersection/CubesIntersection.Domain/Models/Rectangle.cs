using System;

namespace CubesIntersection.Domain.Models
{
    public class Rectangle
    {
        public Coordinate Start { get; private set; }
        public Coordinate End { get; private set; }

        public Rectangle(Coordinate start, Coordinate end)
        {
            this.Start = start;
            this.End = end;
        }

        public float GetVolume()
        {
            return Math.Abs((Start.X - End.X) * (Start.Y - End.Y) * (Start.Y - End.Y));
        }
    }
}
