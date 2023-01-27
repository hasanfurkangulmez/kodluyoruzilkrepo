using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PhoneGuide
{
    public struct Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long PhoneNumber { get; set; }
        public Person(string Name, string Surname, long PhoneNumber)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.PhoneNumber = PhoneNumber;
        }
        public override string ToString() => $"{Name},{Surname},{PhoneNumber}";
        public void Clear()
        {
            Name = null;
            Surname = null;
            PhoneNumber = 0;
        }
    }
}
