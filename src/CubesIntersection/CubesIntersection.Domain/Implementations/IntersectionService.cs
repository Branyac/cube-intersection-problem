using CubesIntersection.Domain.Models;
using System;

namespace CubesIntersection.Domain.Implementations
{
    public class IntersectionService
    {
        public const float PRECISION = 0.1f;

        public Rectangle GetIntersection(Rectangle shapeOne, Rectangle shapeTwo)
        {
            Rectangle result = null;

            Coordinate intersectionFirst = null;
            Coordinate intersectionMax = null;

            for (float posX = Math.Min(shapeOne.Start.X, shapeOne.End.X); posX <= Math.Max(shapeOne.Start.X, shapeOne.End.X); posX += PRECISION)
            {
                for (float posY = Math.Min(shapeOne.Start.Y, shapeOne.End.Y); posY <= Math.Max(shapeOne.Start.Y, shapeOne.End.Y); posY += PRECISION)
                {
                    for (float posZ = Math.Min(shapeOne.Start.Z, shapeOne.End.Z); posZ <= Math.Max(shapeOne.Start.Z, shapeOne.End.Z); posZ += PRECISION)
                    {
                        Coordinate currentCoord = new Coordinate(posX, posY, posZ);

                        if (IsIntersected(currentCoord, shapeTwo))
                        {
                            if (intersectionFirst == null)
                            {
                                intersectionFirst = currentCoord;
                            }

                            intersectionMax = currentCoord;
                        }
                    }
                }
            }

            if (intersectionFirst != null && intersectionMax != null)
            {
                result = new Rectangle(intersectionFirst, intersectionMax);
            }

            return result;
        }

        private bool IsIntersected(Coordinate coord, Rectangle shape)
        {
            bool xAxisIntersection = IsBetween(coord.X, shape.Start.X, shape.End.X);
            bool yAxisIntersection = IsBetween(coord.Y, shape.Start.Y, shape.End.Y);
            bool zAxisIntersection = IsBetween(coord.Z, shape.Start.Z, shape.End.Z);

            return xAxisIntersection && yAxisIntersection && zAxisIntersection;
        }

        private bool IsBetween(float num, float start, float end)
        {
            return num <= Math.Max(start, end) && num >= Math.Min(start, end);
        }
    }
}
