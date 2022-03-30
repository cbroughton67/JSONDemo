using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONDemo
{
    internal class People
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public int Age { get; set; }

        public People() { }

        public People(string fname, string lname, int age)
        {
            FirstName = fname;
            LastName = lname;
            Age = age;
        }
    }
}
