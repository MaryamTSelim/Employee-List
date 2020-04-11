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
        public MenuEventArgs(int index, List<string> items, bool toContinue = true)
        {
            this.Index = index;
            this.Items = items;
            this.ToContinue = toContinue;
        }
    }
}
