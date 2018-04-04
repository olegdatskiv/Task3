using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Point
{
    public double X { get; set; }
    public double Y { get; set; }
}

public class Line
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    private const double EPS = 1e-9;

    public Line()
    {
        A = 0;
        B = 0;
        C = 0;
    }

    public Line(double _a)
    {
        A = _a;
        B = 0;
        C = 0;
    }

    public Line(double _a, double _b)
    {
        A = _a;
        B = _b;
        C = 0;
    }

    public Line(double _a, double _b, double _c)
    {
        A = _a;
        B = _b;
        C = _c;
    }

    public Line(Line previousLine)
    {
        A = previousLine.A;
        B = previousLine.B;
        C = previousLine.C;
    }

    public override bool Equals(object obj)
    {
        var item = obj as Line;

        if (item == null)
        {
            return false;
        }

        return Math.Abs(Determinant(this.A, this.B, item.A, item.B)) < EPS
        && Math.Abs(Determinant(this.A, this.C, item.A, item.C)) < EPS
        && Math.Abs(Determinant(this.B, this.C, item.B, item.C)) < EPS;
    }

    public bool AreIntersected(Line lineObject)
    {
        double denominator = Determinant(this.A, this.B, lineObject.A, lineObject.B);

        if (Math.Abs(denominator) < EPS)
        {
            return false;
        }

        return true;
    }

    public Point FindPointOfIntersection(Line lineObject)
    {
        double denominator = Determinant(this.A, this.B, lineObject.A, lineObject.B);

        if(Math.Abs(denominator) < EPS)
        {
            throw new ArgumentException("These straight lines do not overlap");
        }
        Point pointOfIntersection = new Point
        {
            X = -Determinant(this.C, this.B, lineObject.C, lineObject.B) / denominator,
            Y = -Determinant(this.A, this.C, lineObject.A, lineObject.C) / denominator
        };

        return pointOfIntersection;
    }

    private static double Determinant(double a, double b, double c, double d)
    {
        return a * d - b * c;
    }

    public bool IsPointOnLine(Point pointToCheck)
    {
       return (this.A * pointToCheck.X + this.B * pointToCheck.Y + this.C == 0);
    }

    public bool AreParallel(Line lineObject)
    {
        return Math.Abs(Determinant(this.A, this.B, lineObject.A, lineObject.B)) < EPS;
    }

    public double FindAngleBetweenLines(Line lineObject)
    {
        var angle = (this.A * lineObject.A + this.B * lineObject.B) /
             (Math.Sqrt(Math.Pow(this.A, 2) + Math.Pow(this.B, 2))
            * Math.Sqrt(Math.Pow(lineObject.A, 2) + Math.Pow(lineObject.B, 2)));
        return angle;
    }
}
