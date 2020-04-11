using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Delegate_Menu
{
    class Menu
    {
        public List<string> menuItems { set; get; }
        public ConsoleColor foreColor { set; get; }
        public ConsoleColor backColor  { set; get; }
        public ConsoleColor hforeColor { set; get; }
        public ConsoleColor hbackColor { set; get; }
        public int x { set; get; }
        public int y { set; get; }
        public int currentIndex { set; get; }
        public event EventHandler<MenuEventArgs> OnEnter;
        
        public Menu(List<string> menuItems, ConsoleColor foreColor, ConsoleColor backColor, ConsoleColor hForeColor, ConsoleColor hBackColor, int x, int y, int currentIndex)
        {
            this.menuItems = menuItems;
            this.foreColor = foreColor;
            this.backColor = backColor;
            this.hforeColor = hForeColor;
            this.hbackColor = hBackColor;
            this.x = x;
            this.y = y;
            this.currentIndex = currentIndex;
        }
        public Menu(List<string> menuItems, EventHandler<MenuEventArgs> onMenuEnter) : this(menuItems, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.White, 3, 2, 0)
        {
            this.OnEnter = onMenuEnter;
        }
        public void Draw()
        {
            Console.Clear();
           
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.SetCursorPosition(x, i + y + y*i);
                Console.ForegroundColor = foreColor;
                Console.BackgroundColor = backColor;
               
                if (i == currentIndex)
                {
                    Console.ForegroundColor = hforeColor;
                    Console.BackgroundColor = hbackColor;
                }
                Console.WriteLine(menuItems[i]);
                Console.ResetColor();
            }
        }
        public void Run()
        {
            bool flag = true;
            do
            {
                Draw();
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentIndex--;
                        if (currentIndex < 0)
                            currentIndex = menuItems.Count - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        currentIndex++;
                        if (currentIndex == menuItems.Count)
                            currentIndex = 0;
                        break;

                    case ConsoleKey.Escape:
                        flag = false;
                        break;
                    case ConsoleKey.Enter:
                        MenuEventArgs args = new MenuEventArgs(currentIndex, menuItems);
                        OnEnter(this, args);
                        flag = args.ToContinue;
                        break;
                    default:
                        break;

                }
            }
            while (flag);

        }


    }
}
