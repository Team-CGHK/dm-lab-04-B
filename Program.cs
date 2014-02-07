using System;
using System.Collections.Generic;
using System.IO;

namespace SiscreteMathLab4_B
{
    class Program
    {
        static StreamWriter sw = new StreamWriter("permutations.out");
        static StreamReader sr = new StreamReader("permutations.in");

        static void Main(string[] args)
        {
            int n = int.Parse(sr.ReadLine());
            List<int> set = new List<int>();
            for (int i = 1; i <= n; i++)
                set.Add(i);
            GenerateObj(new List<int>(), set);
            sw.Close();
        }


        static void GenerateObj(List<int> obj, List<int> set)
        {
            if (set.Count == 0)
            {
                foreach (int t in obj)
                    sw.Write(t + " ");
                sw.WriteLine();
            }
            else
                for (int i = 0; i < set.Count; i++)
                {
                    obj.Add(set[0]);
                    set.RemoveAt(0);   
                    GenerateObj(obj, set);
                    set.Add(obj[obj.Count-1]);
                    obj.RemoveAt(obj.Count-1);
                }
        }
    }
}
