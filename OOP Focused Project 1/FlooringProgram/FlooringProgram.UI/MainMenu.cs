using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.UI.Workflows;

namespace FlooringProgram.UI
{
    public class MainMenu
    {
        public void ShowMainMenu()
        {
            bool isValid = true;
            string s = "WELCOME TO THE FLOORING PROGRAM!";
            
            do
            {
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
                Console.WriteLine("\nWHAT WOULD YOU LIKE TO DO?\n\n");
                Console.WriteLine("1. ADD ORDER\n");
                Console.WriteLine("2. SEARCH/DISPLAY ORDER\n");
                Console.WriteLine("3. EDIT ORDER\n");
                Console.WriteLine("4. REMOVE ORDER\n");
                Console.WriteLine("5. QUIT PROGRAM\n\n");
                string choice = Console.ReadLine().ToUpper();

                if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "Q")
                {
                    Console.WriteLine("That wasn't a valid input!");
                    Console.WriteLine("Press ANY KEY to try again!");
                    Console.ReadKey();
                    Console.Clear();
                    isValid = false;
                }

                else
                { 
                    isValid = true;
                    ProcessInput(choice);
                }
            } while (!isValid);
            
        }

        private void ProcessInput(string choice)
        {
           CreateOrderWorkflow create = new CreateOrderWorkflow();
            EditOrderWorkflow edit = new EditOrderWorkflow();
            OrderSearchWorkflow search = new OrderSearchWorkflow();
            DeleteOrderWorkflow delete = new DeleteOrderWorkflow();
            

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    create.Excecute();
                    ShowMainMenu();
                    break;
                case "2":
                    Console.Clear();
                    search.Execute();
                    ShowMainMenu();
                    break;
                case "3":
                    Console.Clear();
                   edit.Execute();
                   ShowMainMenu();
                    break;
                case "4":
                    Console.Clear();
                   delete.Execute();
                   ShowMainMenu();
                    break;
                case "5":
                case "Q":
                    Console.WriteLine("Press ANY KEY to exit!");
                    break;
            }
        }
    }
}
