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
        private const uint COEFFICIENTSAMOUNT = 3;
        private static List<Line> lines = new List<Line>();
        private static void Input(string[] inputData)
        {
            foreach (var item in inputData)
            {
                List<double> coefficients = new List<double>();

                string number = "";
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] == '-' && number != "")
                    {
                        if (number.Length != 0 && coefficients.Count < COEFFICIENTSAMOUNT)
                        {
                            coefficients.Add(Double.Parse(number));
                        }
                        number = "";
                    }
                    if (item[i] >= '0' && item[i] <= '9' || item[i] == ',' || item[i] == '-')
                    {
                        number += item[i];
                    }
                    else
                    {
                        if (number.Length != 0 && coefficients.Count < 3)
                        {
                            coefficients.Add(Double.Parse(number));
                        }
                        number = "";
                    }
                }
                Line additionalLine = new Line();
                additionalLine.A = coefficients[0];
                additionalLine.B = coefficients[1];
                additionalLine.C = coefficients[2];
                lines.Add(additionalLine);
            }
        }
        private static void Task1()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.txt");
            string[] inputData = File.ReadAllLines(path);

            Input(inputData);
            List<string> task1Answers = new List<string>();
            foreach (var line1 in lines)
            {
                foreach (var line2 in lines)
                {
                    if (line1.AreIntersected(line2))
                    {
                        var point = line1.FindPointOfIntersection(line2);
                        string answer = $"Line {line1.A.ToString()}x + {line1.B.ToString()}y + {line1.C.ToString()}=0 " +
                                  $"with line {line2.A.ToString()}x+ {line2.B.ToString()}y+ {line2.C.ToString()}=0" +
                                  $" have such a point of intersection (x,y) = ({point.X.ToString()},{point.Y.ToString()})";
                        task1Answers.Add(answer);
                    }
                }
            }
            path = "";
            path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data1.txt");
            File.WriteAllLines(path, task1Answers);
        }

        private static void Task2()
        {
            Line lineOX = new Line(0, 1, 0);
            List<string> task2Answers = new List<string>();
            foreach (var line in lines)
            {
                if (line.AreParallel(lineOX))
                {
                    string answer = $"Line {line.A.ToString()}x + {line.B.ToString()}y + {line.C.ToString()}=0 " +
                                  $"with line {lineOX.A.ToString()}x+ {lineOX.B.ToString()}y+ {lineOX.C.ToString()}=0" +
                                  " is parallel";
                    task2Answers.Add(answer);
                }
            }
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data2.txt");
            File.WriteAllLines(path, task2Answers);
            task2Answers.Clear();

            foreach (var line in lines)
            {
                if (line.FindAngleBetweenLines(lineOX) == 0)
                {
                    string answer = $"Line {line.A.ToString()}x + {line.B.ToString()}y + {line.C.ToString()}=0 " +
                                  $"with line {lineOX.A.ToString()}x+ {lineOX.B.ToString()}y+ {lineOX.C.ToString()}=0" +
                                  "intersect at right angles";
                    task2Answers.Add(answer);
                }
            }
            path = "";
            path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data3.txt");
            File.WriteAllLines(path, task2Answers);
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
        }
    }
}
