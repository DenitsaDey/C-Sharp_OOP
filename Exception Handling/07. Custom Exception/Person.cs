﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Valid_Person
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName)
        {
            this.FirstName = firstName;
        }
        public Person(string firstName, string lastName, int age)
            :this(firstName)
        {
            this.LastName = lastName;
            this.Age = age;
        }

        public virtual string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "The first name cannot be null or empty.");
                }
                
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "The last name cannot be null or empty.");
                }
                this.lastName = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if(0>value || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value", "Age should be in the range[0 ... 120].");
                }
                this.age = value;
            }
        }
    }
}
