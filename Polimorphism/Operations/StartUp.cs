﻿using System;

namespace Operations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MathOperations mo = new MathOperations();
            Console.WriteLine(mo.Add(2,3));
            Console.WriteLine(mo.Add(2.2, 3.3, 4.4));
            Console.WriteLine(mo.Add(2.2m, 3.3m, 4.4m));
        }
    }
}