using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task3_2_
{
    class Program
    {
        private static List<Line> lines = new List<Line>();
        private static void Task1()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.txt");
            string[] inputData = File.ReadAllLines(path);
            foreach (var it in inputData)
            {
                List<double> data = new List<double>();

                string numb = "";
                for (int i = 0; i < it.Length; i++)
                {
                    if (it[i] == '-' && numb != "")
                    {
                        if (numb.Length != 0 && data.Count < 3)
                        {
                            data.Add(Double.Parse(numb));
                        }
                        numb = "";
                    }
                    if (it[i] >= '0' && it[i] <= '9' || it[i] == ',' || it[i] == '-')
                    {
                        numb += it[i];
                    }
                    else
                    {
                        if (numb.Length != 0 && data.Count < 3)
                        {
                            data.Add(Double.Parse(numb));
                        }
                        numb = "";
                    }
                }
                Line tmp = new Line();
                tmp.A = data[0];
                tmp.B = data[1];
                tmp.C = data[2];
                lines.Add(tmp);
            }

            List<string> ans = new List<string>();
            foreach (var it in lines)
            {
                foreach (var it2 in lines)
                {
                    if (it.IsIntersection(it2))
                    {
                        string line = "Line " + it.A.ToString() + "x+" + it.B.ToString() + "y+" + it.C.ToString() + "=0";
                        line += " with line " + it2.A.ToString() + "x+" + it2.B.ToString() + "y+" + it2.C.ToString() + "=0";
                        var point = it.Intersection(it2);
                        line += " have such a point of intersection (x,y) = " + '(' + point.Item1.ToString() + ',' + point.Item2.ToString() + ')';
                        ans.Add(line);
                    }
                }
            }
            path = "";
            path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data1.txt");
            File.WriteAllLines(path, ans);
        }

        private static void Task2()
        {
            Line line = new Line(0, 1, 0);
            List<string> ans = new List<string>();
            foreach (var it in lines)
            {
                if (!it.Parallel(line))
                {
                    string str = "Line " + it.A.ToString() + "x+" + it.B.ToString() + "y+" + it.C.ToString() + "=0";
                    str += " with line " + line.A.ToString() + "x+" + line.B.ToString() + "y+" + line.C.ToString() + "=0";
                    str += " is parallel";
                    ans.Add(str);
                }
            }
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data2.txt");
            File.WriteAllLines(path, ans);
            ans.Clear();

            foreach (var it in lines)
            {
                if (it.Angle(line) == 0)
                {
                    string str = "Line " + it.A.ToString() + "x+" + it.B.ToString() + "y+" + it.C.ToString() + "=0";
                    str += " with line " + line.A.ToString() + "x+" + line.B.ToString() + "y+" + line.C.ToString() + "=0";
                    str += " intersect at right angles";
                    ans.Add(str);
                }
            }
            path = "";
            path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data3.txt");
            File.WriteAllLines(path, ans);
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
        }
    }
}
