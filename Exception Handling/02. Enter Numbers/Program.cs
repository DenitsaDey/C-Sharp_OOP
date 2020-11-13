using System;

namespace _02._Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;

            for (int i = 1; i <= 10; i++)
            {
                string n = Console.ReadLine();
                try
                {
                    ReadNumber(n, start, end);
                }
                catch (ArgumentOutOfRangeException)
                {
                    i = 0;
                    Console.WriteLine("Start again!");
                }
                catch (FormatException fe)
                {
                    i = 0;
                    Console.WriteLine(fe.Message);
                }
            }
        }

        private static int ReadNumber(string num, int start, int end)
        {
            int n = 0;

            try
            {
                n = int.Parse(num);
            }
            catch (FormatException)
            {
                throw new FormatException("Entry is not an integer");
            }

            if (start >= n || n >= end)
            {
                throw new ArgumentOutOfRangeException("Number was out of specified range!");
            }
            return n;
        }
    }
}
