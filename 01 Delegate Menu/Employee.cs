using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Delegate_Menu
{
    class Employee
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public int Id { get; set; }
        private const int currentYear = 2020;
       
        public Employee(int Id ,string name , int birthyear )
        {
            this.Id = Id ;
            this.Name = name;
            this.BirthYear = birthyear;
        }
        public override string ToString() {
            return $"ID : {this.Id}\t\tName : {this.Name}\t\tAge : {currentYear - this.BirthYear}";
        }

    }
}
