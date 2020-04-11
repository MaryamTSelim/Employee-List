using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Delegate_Menu
{
    internal class MenuEventArgs
    {
        public int Index { get; set; }
        public List<string> Items { get; set; }
        public bool ToContinue { get; set; }
        public List<Employee> Employees { get; set; }
        public int ID { get; set; }
        public MenuEventArgs(int index, List<string> Items, bool toContinue = true)
        {
            this.Index = index;
            this.Items = Items;
            this.ToContinue = toContinue;
        }
        public MenuEventArgs(int index, List<Employee> employees, bool toContinue = true)
        {
            this.Index = index;
            this.Employees = employees;
            this.ToContinue = toContinue;
        }
        public MenuEventArgs(int index, bool toContinue = true)
        {
            this.Index = index;
            this.ToContinue = toContinue;
        }
        public MenuEventArgs(int index,int id, bool toContinue = true)
        {
            this.Index = index;
            this.ID = id;
            this.ToContinue = toContinue;
        }
        public MenuEventArgs(int index, List<Employee> employees,int id, bool toContinue = true)
        {
            this.Index = index;
            this.Employees = employees;
            this.ToContinue = toContinue;
            this.ID = id;
        }
    }
}
