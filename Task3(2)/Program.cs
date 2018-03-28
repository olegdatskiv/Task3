using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = System.IO.File.ReadAllLines(@"D:\Algotester\Task3(2)\Task3(2)\data.txt");
            List<Line> lines = new List<Line>();
            foreach(var it in inputData)
            {
                List<double> data = new List<double>();

                string numb = "";
                for (int i = 0; i < it.Length; i++)
                {
                    if(it[i] >= '0' && it[i] <= '9' || it[i] == ',' || it[i] == '-')
                    {
                        numb += it[i];
                    }
                    else
                    {
                        if(numb.Length != 0 && data.Count < 3)
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

            foreach(var it in lines)
            {
                Console.WriteLine("{0} {1} {2}", it.A, it.B, it.C);
            }
            Console.ReadKey();
        }
    }
}
