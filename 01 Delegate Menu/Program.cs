using System;
using System.Collections.Generic;
using System.Text;
namespace _01_Delegate_Menu
{
    delegate void printAll(List<Employee > listOfEmployees);
    class Program
    {
        public static List<Employee> listOfEmployees = new List<Employee> { new Employee(1,"Maryam",1996) , new Employee(2,"Esraa", 1997)
                                                            , new Employee(3,"Bassant", 1995) , new Employee(4,"Reem",1996)};
        static void Main(string[] args)
        {
            List<string> menuItems = new List<string> { "Print All Employees", "Print Employee By ID", "Add Employee"
                                                               , "Edit Employee", "Delete Employee", "Exit"};
            
            //ConsoleColor foreColor = ConsoleColor.White;
            //ConsoleColor backColor = ConsoleColor.DarkGray;
            //ConsoleColor hforeColor = ConsoleColor.Black;
            //ConsoleColor hbackColor = ConsoleColor.White;
            //Menu menu = new Menu(menuItems, foreColor, backColor, hforeColor, hbackColor, 5, 1, 0 );
            Menu menu = new Menu(menuItems, HandleMenuEnter);
            menu.Run();

            Console.WriteLine("\nPress Any Key To Exit");
            Console.ReadLine();
        }
        static void HandleMenuEnter(object sender, MenuEventArgs e)
        {
            Console.Clear();
            Menu m = sender as Menu; 
            switch (m.currentIndex)
            {
                case 0:
                    printAll(listOfEmployees);
                    break;
                case 1:
                    int printID = getID();
                    printById(printID);
                    break;
                case 2:
                    addEmployee();
                    break;
                case 3:
                    int editID = getID();
                    editEmployee(editID);
                    break;
                case 4:
                    int deleteID = getID();
                    deleteEmployee(deleteID);
                    break;
                default:
                    e.ToContinue = false;
                    return;
            }
            
            Console.ReadLine();
            e.ToContinue = true;
        }
        static void printAll(List<Employee> listOfEmployees)
        {
            foreach (var employee in listOfEmployees)
            {
                Console.WriteLine(employee);
            }
        }
        static int getID()
        {
            Console.Clear();
            Console.Write("Enter ID :\t");
            return Int32.Parse(Console.ReadLine());
        }
        static int printById(int id)
        {
            Console.Clear();
            int i = 0;
            int index = -1;
            bool isPrinted = false;
            do
            {
                if (listOfEmployees[i].Id == id)
                {
                    index = i;
                    Console.WriteLine(listOfEmployees[i]);
                    isPrinted = true;
                }
                i++;
            } while (i<listOfEmployees.Count && !isPrinted);
            return index ;
        }
        static void addEmployee()
        {
            Console.Clear();
            Console.Write("Name :\t");
            string Name = Console.ReadLine();
            Console.Write("BirthYear :\t");
            int BirthYear = Int32.Parse(Console.ReadLine());
            listOfEmployees.Add(new Employee(listOfEmployees.Count + 1,Name,BirthYear));
        }
        static void deleteEmployee(int id)
        {
            var index = printById(id);
            if (index < 0)
            {
                Console.WriteLine("No element Exists with this ID");
            }
            else
            {
                var rem = listOfEmployees[index];
                listOfEmployees.Remove(rem);
                Console.WriteLine("\nis successfully removed");
                
            }
            
        }
        static void editEmployee(int id)
        {
            var index = printById(id);
            if(index < 0)
            {
                Console.WriteLine("No element Exists with this ID");
            }
            else
            {
                Console.Write("Edited Name :\t");
                string Name = Console.ReadLine();
                Console.Write("Edited BirthYear :\t");
                int BirthYear = Int32.Parse(Console.ReadLine());
                listOfEmployees[index].Name = Name;
                listOfEmployees[index].BirthYear = BirthYear;
            }
        }
    }
}
