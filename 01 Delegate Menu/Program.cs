using System;
using System.Collections.Generic;
using System.Text;
namespace _01_Delegate_Menu
{
    delegate void printAll(List<Employee> listOfEmployees);
    class Program
    {
        public static List<Employee> listOfEmployees = new List<Employee> { new Employee(1,"Maryam",1996) , new Employee(2,"Esraa", 1997)
                                                            , new Employee(3,"Bassant", 1995) , new Employee(4,"Reem",1996)};
        static void Main(string[] args)
        {
            List<string> menuItems = new List<string> { "Print All Employees", "Print Employee By ID", "Add Employee"
                                                               , "Edit Employee", "Delete Employee", "Exit"};

            Menu menu = new Menu(menuItems, HandlePrintAll, HandlePrintByID, HandleGetID, HandleAdd, HandleEdit, HandleRemove);
            menu.Run();

            Console.WriteLine("\nPress Any Key To Exit");
            Console.ReadLine();
        }

        static void HandlePrintAll(object sender, MenuEventArgs e)
        {
            foreach (var employee in e.Employees)
            {
                Console.WriteLine(employee);
            }
        }
        static void HandleGetID(object sender, MenuEventArgs e)
        {
            Console.Clear();
            Console.Write("Enter ID :\t");
            e.ID = Int32.Parse(Console.ReadLine());
        }

        static void HandlePrintByID(object sender, MenuEventArgs e)
        {
            Console.Clear();
            int i = 0;
            int index = -1;
            bool isPrinted = false;
            do
            {
                if (listOfEmployees[i].Id == e.ID)
                {
                    index = i;
                    Console.WriteLine(listOfEmployees[i]);
                    isPrinted = true;
                }
                i++;
            } while (i < listOfEmployees.Count && !isPrinted);
        }
        static void HandleAdd(object sender, MenuEventArgs e)
        {
            Console.Clear();
            Console.Write("name :\t");
            string name = Console.ReadLine();
            Console.Write("birthyear :\t");
            int birthyear = Int32.Parse(Console.ReadLine());
            e.Employees.Add(new Employee(e.Employees.Count + 1, name, birthyear));
        }

        static void HandleRemove(object sender, MenuEventArgs e)
        {
            Console.Clear();
            int i = 0;
            bool isFound = false;
            do
            {
                if (e.Employees[i].Id == e.ID)
                {
                    var rem = e.Employees[i];
                    e.Employees.Remove(rem);
                    Console.WriteLine($"{rem}\nis successfully removed");
                    isFound = true;
                }
                i++;
            } while (i < e.Employees.Count && !isFound);


        }
        static void HandleEdit(object sender, MenuEventArgs e)
        {
            Console.Clear();
            int i = 0;
            bool isFound = false;
            do
            {
                if (e.Employees[i].Id == e.ID)
                {
                    var rem = e.Employees[i];
                    
                    Console.WriteLine($"{rem}\n");
                    Console.Write("Edited Name :\t");
                    string name = Console.ReadLine();
                    Console.Write("Edited Birth Year :\t");
                    int birthyear = Int32.Parse(Console.ReadLine());
                    e.Employees[i].Name = name;
                    e.Employees[i].BirthYear = birthyear;
                    isFound = true;
                }
                i++;
            } while (i < e.Employees.Count && !isFound);


               
                
            
        }
    }
}
