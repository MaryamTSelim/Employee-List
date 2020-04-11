using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Delegate_Menu
{
    class Menu
    {
        public static List<Employee> listOfEmployees = new List<Employee> { new Employee(1,"Maryam",1996) , new Employee(2,"Esraa", 1997)
                                                            , new Employee(3,"Bassant", 1995) , new Employee(4,"Reem",1996)};
        public List<string> menuItems { set; get; }
        public ConsoleColor foreColor { set; get; }
        public ConsoleColor backColor { set; get; }
        public ConsoleColor hforeColor { set; get; }
        public ConsoleColor hbackColor { set; get; }
        public int x { set; get; }
        public int y { set; get; }
        public int currentIndex { set; get; }
        public event EventHandler<MenuEventArgs> OnPrintAll;
        public event EventHandler<MenuEventArgs> OnPrintByID;
        public event EventHandler<MenuEventArgs> OnAdd;
        public event EventHandler<MenuEventArgs> OnEdit;
        public event EventHandler<MenuEventArgs> OnDelete;
        public event EventHandler<MenuEventArgs> OnGetByID;


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
        public Menu(List<string> menuItems, EventHandler<MenuEventArgs> HandlePrintAll, EventHandler<MenuEventArgs> HandlePrintByID, EventHandler<MenuEventArgs> HandleGetID,
            EventHandler<MenuEventArgs> HandleAdd, EventHandler<MenuEventArgs> HandleEdit, EventHandler<MenuEventArgs> HandleRemove)
            : this(menuItems, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.White, 3, 2, 0)
        {
            this.OnPrintAll = HandlePrintAll;
            this.OnPrintByID = HandlePrintByID;
            this.OnGetByID = HandleGetID;
            this.OnAdd = HandleAdd;
            this.OnEdit = HandleEdit;
            this.OnDelete = HandleRemove ;

        }
        public void Draw()
        {
            Console.Clear();

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.SetCursorPosition(x, i + y + y * i);
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
                        //MenuEventArgs args = new MenuEventArgs(currentIndex, menuItems);
                        //OnEnter(this, args)  
                        Console.Clear();
                        switch (currentIndex)
                        {
                            case 0:
                                OnPrintAll(this, new MenuEventArgs(currentIndex, listOfEmployees));
                                break;
                            case 1:
                                var arg1 = new MenuEventArgs(currentIndex, 0);
                                OnGetByID(this, arg1);
                                int printid = arg1.ID;
                                OnPrintByID(this, new MenuEventArgs(currentIndex, listOfEmployees, printid));
                                break;
                            case 2:
                                var arg2 = new MenuEventArgs(currentIndex, listOfEmployees);
                                OnAdd(this,arg2);
                                listOfEmployees = arg2.Employees;
                                break;
                            case 3:
                                var arg3 = new MenuEventArgs(currentIndex, 0);
                                OnGetByID(this, arg3);
                                int editID = arg3.ID;
                                var arg4 = new MenuEventArgs(currentIndex, listOfEmployees, editID);
                                OnEdit(this, arg4);
                                listOfEmployees = arg4.Employees;
                                break;
                            case 4:
                                var arg5 = new MenuEventArgs(currentIndex, 0);
                                OnGetByID(this, arg5);
                                int deleteID = arg5.ID;
                                var arg6 = new MenuEventArgs(currentIndex, listOfEmployees, deleteID);
                                OnDelete(this, arg6 );
                                listOfEmployees = arg6.Employees;
                                break;
                            default:
                                flag = false;
                                return;
                        }
                        Console.ReadLine();
                        break;
                    default:
                        break;

                }
            }
            while (flag);

        }


    }
}
