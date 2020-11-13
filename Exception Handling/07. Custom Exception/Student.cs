using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Valid_Person
{
    public class Student : Person
    {
        public Student(string firstName, string email)
            : base(firstName)
        {
            this.Email = email;
        }

        public string Email { get; private set; }

        public override string FirstName
        {
            get => base.FirstName;
            set
            {
                if (!value.All(c => char.IsLetter(c)))
                {
                    throw new InvalidPersonNameException();
                }
                base.FirstName = value;
            }
        }
    }
}
