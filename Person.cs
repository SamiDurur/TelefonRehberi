using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Person
    {
        private string name;
        private string surname;
        private ulong number;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public ulong Number
        {
            get => number;
            set
            {
                if (value > 1000000000 && value < 10000000000)
                    number = value;
                else
                {
                    number = 1000000000;
                }
            }
        }
        public Person(string name, string surname, ulong number)
        {
            Name = name;
            Surname = surname;
            Number = number;
        }
        public Person()
        {
        }

    }
}
