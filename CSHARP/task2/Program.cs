﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("2,-2,4,7"));
            s.Add(new LinearEquation("-3,9,7,3"));
            s.Add(new LinearEquation("-3,4,-9,11"));
            s.StepView();

            double[] solve = s.Solve();
            Console.WriteLine(s.ToString());
            Console.Write("Ответ: ");
            for (int i = 0; i < solve.Length; ++i)
                Console.Write(solve[i] + " ");

            Console.ReadKey();
        }
    }
}
