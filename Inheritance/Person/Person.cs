using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual int Age
        {
            get { return age; }
            set
            {
                if (age < 0)
                {
                    throw new ArgumentException("Person'a age must be a positive number.");

                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format($"Name: {this.Name}, Age: {this.Age}"));
            return sb.ToString();

        }

    }
}
