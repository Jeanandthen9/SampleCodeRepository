using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;

namespace FlooringProgram.UI.Workflows
{
    public class CreateOrderWorkflow
    {
        public void Excecute()
        {
            bool isValid = true;
            bool redo = true;

            
            do
            {
                string name = GetNameForOrder();
                string state = GetFullStateNameForOrder();
                string productType = GetProductTypeNameForOrder();
                decimal area = GetProductAreaForOrder();

                do
                {
                    Console.Clear();
                    string s = "***PLEASE REVIEW***";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.WriteLine($"\nNAME: {name}");
                    Console.WriteLine($"STATE: {state}");
                    Console.WriteLine($"PRODUCT TYPE: {productType}");
                    Console.WriteLine($"AREA: {area} square feet\n");

                    Console.WriteLine("Is this information correct?\n");
                    Console.WriteLine("1. YES - This information is correct.");
                    Console.WriteLine("2. NO - There's some errors. I would like to start over.");
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == "1" || answer == "Y" || answer == "YES")
                    {
                        Console.Clear();
                        ProcessNewAccount(name, state, productType, area);
                        isValid = true;
                        redo = false;
                    }
                    else if (answer == "2" || answer == "N" || answer == "NO")
                    {
                        Console.Clear();
                        isValid = false;
                        redo = true;
                    }
                    else
                    {
                        Console.WriteLine("\nThat wasn't a valid input!");
                        Console.WriteLine("Press ANY KEY to try again!");
                        Console.ReadKey();
                        isValid = false;
                        redo = false;
                    }
                } while (isValid == false && redo == false);
            } while (isValid == false && redo == true);
        }

        private string GetNameForOrder()
        {
            bool isValid = true;
            string name;

            do
            {
                string s = "***PLACING NEW ORDER***";
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
                Console.WriteLine("\nPlease fill in the following information to complete your order:\n");
                Console.Write($"NAME OF COMPANY/INDIVIDUAL THAT IS PLACING THE ORDER: ");
                name = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(name))
                {
                    Console.Clear();
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nYou did not enter anything!");
                    Console.WriteLine("Press ANY KEY to try again!");
                    Console.ReadKey();
                    Console.Clear();
                    isValid = false;
                }
            } while (!isValid);
            return name;
        }

        private string GetFullStateNameForOrder()
        {
            bool isValid = true;
            string state;

            do
            {
                string s = "***PLACING NEW ORDER***";
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
                Console.WriteLine("\nPlease fill in the following information to complete your order:\n");
                Console.Write($"FULL NAME OF STATE WHERE COMPANY/INDIVIDUAL IS LOCATED: ");
                state = Console.ReadLine().ToUpper();

                if (!String.IsNullOrWhiteSpace(state))
                {
                    Console.Clear();
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nYou did not enter anything!");
                    Console.WriteLine("Press ANY KEY to try again!");
                    Console.ReadKey();
                    Console.Clear();
                    isValid = false;
                }
            } while (!isValid);
            return state;
        }

        private string GetProductTypeNameForOrder()
        {
            bool isValid = true;
            string productType;

            do
            {
                string s = "***PLACING NEW ORDER***\n";
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
                Console.WriteLine("Please fill in the following information to complete your order:\n");
                Console.Write($"PRODUCT TYPE REQUESTED: ");
                productType = Console.ReadLine().ToUpper();

                if (!String.IsNullOrWhiteSpace(productType))
                {
                    Console.Clear();
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nYou did not enter anything!");
                    Console.WriteLine("Press ANY KEY to try again!");
                    Console.ReadKey();
                    Console.Clear();
                    isValid = false;
                }
            } while (!isValid);
            return productType;
        }

        private decimal GetProductAreaForOrder()
        {
            bool isValid = true;
            string area;
            decimal expected;

            do
            {
                string s = "***PLACING NEW ORDER***\n";
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
                Console.WriteLine("Please fill in the following information to complete your order:\n");
                Console.Write($"TOTAL AREA NEEDED (PER SQUARE FOOT): ");
                area = Console.ReadLine();

                if (decimal.TryParse(area, out expected) == false)
                {
                    Console.WriteLine("\nThat was not a valid entry!");
                    Console.WriteLine("Press ANY KEY to try again!");
                    Console.ReadKey();
                    Console.Clear();
                    isValid = false;
                }
                else if (!String.IsNullOrWhiteSpace(area))
                {
                    Console.Clear();
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nYou did not enter anything!");
                    Console.WriteLine("Press ANY KEY to try again!");
                    Console.ReadKey();
                    Console.Clear();
                    isValid = false;
                }
            } while (!isValid);
            return expected;
        }

        private void ProcessNewAccount(string name, string state, string productType, decimal area)
        {
            OrderProcessing request = new OrderProcessing();
            Response response = request.AddNewOrder(name, state, productType, area);

            if (response.Success)
            {
                OrderSummaryWorkflow summary = new OrderSummaryWorkflow();
                summary.ExecuteNewOrderSummary(response.OrderInfo);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
