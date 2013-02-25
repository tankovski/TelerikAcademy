using System;

static class CalculateDistanceBetweenTwo3DPoints
{
    public static double Calculate(Point3D pointA, Point3D pointB)
    {
        double result = Math.Sqrt(Math.Pow(pointB.X - pointA.X, 2) + Math.Pow(pointB.Y - pointA.Y, 2) + Math.Pow(pointB.Z - pointA.Z, 2));
        return result;
    }
}

