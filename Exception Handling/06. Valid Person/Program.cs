using System;

namespace _06._Valid_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Person("Ivan", "Petrov", 24);
                Person noName = new Person(string.Empty, "Goshev", 31);
                Person noLastName = new Person("Ivan", null, 63);
                Person negativeAge = new Person("Stoyan", "Kolev", -1);
                Person tooOldForThisProgram = new Person("Kiril", "Todorov", 121);
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
