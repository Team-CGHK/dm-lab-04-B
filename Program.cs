using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace SiscreteMathLab4_B
{
    class Program
    {
        static StreamWriter sw = new StreamWriter("permutations.out");
        static StreamReader sr = new StreamReader("permutations.in");

        static void Main(string[] args)
        {
            int n = int.Parse(sr.ReadLine());
            int[] set = new int[n];
            for (int i = 0; i < n; i++)
                set[i] = i+1;
            GenerateObj(new List<int>(), set, new bool[set.Length]);
            sw.Close();
        }


        static void GenerateObj(List<int> obj, int[] set, bool[] used)
        {
            if (used.All(x => x))
            {
                foreach (int t in obj)
                    sw.Write(t + " ");
                sw.WriteLine();
            }
            else
                for (int i = 0; i < set.Length; i++)
                    if (!used[i])
                    {
                        obj.Add(set[i]);
                        used[i] = true;
                        GenerateObj(obj, set, used);
                        used[i] = false;
                        obj.RemoveAt(obj.Count - 1);
                    }
        }
    }
}
