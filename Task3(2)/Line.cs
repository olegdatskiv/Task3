using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Line
{
    private double a;
    private double b;
    private double c;

    public double A { get { return a; } set { a = value; } }
    public double B { get { return b; } set { b = value; } }
    public double C { get { return c; } set { c = value; } }


    private const double EPS = 1e-9;

    public Line()
    {
        a = 0;
        b = 0;
        c = 0;
    }

    public Line(double _a, double _b, double _c)
    {
        a = _a;
        b = _b;
        c = _c;
    }

    public Line(Line previousLine)
    {
        a = previousLine.a;
        b = previousLine.b;
        c = previousLine.c;
    }

    public override bool Equals(object obj)
    {
        var item = obj as Line;

        if (item == null)
        {
            return false;
        }

        return Math.Abs(Determinant(this.a, this.b, item.a, item.b)) < EPS
        && Math.Abs(Determinant(this.a, this.c, item.a, item.c)) < EPS
        && Math.Abs(Determinant(this.b, this.c, item.b, item.c)) < EPS;
    }

    public bool AreIntersected(Line lineObject)
    {
        double denominator = Determinant(this.a, this.b, lineObject.a, lineObject.b);

        if (Math.Abs(denominator) < EPS)
        {
            return false;
        }

        return true;
    }

    public Tuple<double,double> FindPointOfIntersection(Line lineObject)
    {
        double denominator = Determinant(this.a, this.b, lineObject.a, lineObject.b);

        if(Math.Abs(denominator) < EPS)
        {
            throw new ArgumentException("These straight lines do not overlap");
        }

        double x = -Determinant(this.c, this.b, lineObject.c, lineObject.b) / denominator;
        double y = -Determinant(this.a, this.c, lineObject.a, lineObject.c) / denominator;

        return Tuple.Create(x, y);
    }

    private static double Determinant(double a, double b, double c, double d)
    {
        return a * d - b * c;
    }

    public bool IsPointOnLine(Tuple<double,double> point)
    {
        if(this.a*point.Item1 + this.b*point.Item2 + this.c == 0)
        {
            return true;
        }
        else

        {
            return false;
        }
    }

    public bool AreParallel(Line lineObject)
    {
        return Math.Abs(Determinant(this.a, this.b, lineObject.a, lineObject.b)) < EPS;
    }

    public double FindAngleBetweenLines(Line lineObject)
    {
        return (this.a * lineObject.a + this.b * lineObject.b) 
            / (Math.Sqrt(Math.Pow(this.a, 2) + Math.Pow(this.b, 2))
            *  Math.Sqrt(Math.Pow(lineObject.a, 2) + Math.Pow(lineObject.b, 2)));
    }
}
