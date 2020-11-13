using System;

namespace _01._Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            try
            {
                if (n < 0)
                {
                    throw new InvalidOperationException();
                }
                Console.WriteLine(Math.Pow(n, 2));
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
