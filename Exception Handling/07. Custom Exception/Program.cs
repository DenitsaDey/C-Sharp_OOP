using System;

namespace _06._Valid_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Student("Gin4o", "email");
                
            }
            catch(InvalidPersonNameException ipn)
            {
                Console.WriteLine("Exception thrown: {0}", ipn.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException aor)
            {
                Console.WriteLine("Exception thrown: {0}", aor.Message);
            }
        }
    }
}
