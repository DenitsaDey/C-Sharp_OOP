using System;


namespace _05._Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = string.Empty;
            while ((num = Console.ReadLine()) != "END")
            {
                try
                {
                    double n = Convert.ToDouble(num);
                    Console.WriteLine(n);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (OverflowException ofe)
                {
                    Console.WriteLine(ofe.Message);
                }
            }
        }
        
    }
}
