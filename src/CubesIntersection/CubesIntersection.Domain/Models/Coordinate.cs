namespace CubesIntersection.Domain.Models
{
    public class Coordinate
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Coordinate(float x, float y , float z) {
            X = x;
            Y = y;
            Z = z;
        }

        public Coordinate Clone()
        {
            return new Coordinate(X, Y, Z);
        }
    }
}
