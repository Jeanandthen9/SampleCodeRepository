using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;

namespace FlooringProgram.UI.Workflows
{
    public class OrderSummaryWorkflow
    {
        
        public void ExecuteNewOrderSummary(Order order)
        {
            DisplayNewOrderSummary(order);
        }

        public void ExecuteExistingOrderSummary(Order order)
        {
            DisplayExistingOrderSummary(order);
        }

        public void ExecuteEditedOrderSummary(Order editedOrder)
        {
            DisplayEditedOrderSummary(editedOrder);
        }

        private void PrintNewOrderSummary(Order order)
        {
            string s = "***SUMMARY OF YOUR NEW ORDER***";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.WriteLine($"\nNAME OF COMPANY/INDIVIDUAL: {order.CustomerName}\n");
            Console.WriteLine($"COMPANY/INDIVIDUAL'S STATE: {order.State.StateName}\n");
            Console.WriteLine($"PRODUCT ORDERED: {order.ProductType.Type}\n");
            Console.WriteLine($"AREA REQUESTED: {order.Area} square feet\n");
            Console.WriteLine($"COST OF LABOR PER SQUARE FOOT: ${order.ProductType.LaborCost}\n");
            Console.WriteLine($"COST OF MATERIAL PER SQUARE FOOT: ${order.ProductType.MaterialCost}\n");
            Console.WriteLine(
                $"{order.State.StateName.ToUpper()}'S TAX RATE: {order.State.TaxRate}%\n");
            Console.WriteLine(
                $"TOTAL PRICE OF ORDER: {order.PriceTotal.ToString("C", CultureInfo.CurrentCulture)}\n");
        }

        public void PrintExistingOrderSummary(Order order)
        {
            string s = "***SUMMARY OF YOUR EXISTING ORDER***";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.WriteLine($"\nORDER NUMBER: {order.OrderNumber}\n");
            Console.WriteLine($"DATE ORDER WAS PLACED: {order.OrderDate}\n");
            Console.WriteLine($"NAME OF COMPANY/INDIVIDUAL: {order.CustomerName}\n");
            Console.WriteLine($"COMPANY/INDIVIDUAL'S STATE: {order.State.StateName}\n");
            Console.WriteLine($"PRODUCT ORDERED: {order.ProductType.Type}\n");
            Console.WriteLine($"AREA REQUESTED: {order.Area} square feet\n");
            Console.WriteLine($"TOTAL PRICE OF ORDER: {order.PriceTotal.ToString("C", CultureInfo.CurrentCulture)}\n");
        }

        private void DisplayNewOrderSummary(Order order)
        {
                PrintNewOrderSummary(order);

                RequestForNewOrderEdit(order);
        }

        private void DisplayExistingOrderSummary(Order order)
        {

                PrintExistingOrderSummary(order);

                RequestForExistingOrderEdit(order);
        }

        private void DisplayEditedOrderSummary(Order editedOrder)
        {
                PrintExistingOrderSummary(editedOrder);

                RequestForExistingOrderEdit(editedOrder);
            
        }

        private void RequestForNewOrderEdit(Order order)
        {
            
           bool isValid = true;

            do
            {
                Console.WriteLine("\nIs the summary of this new order correct?\n");
                Console.WriteLine("1. YES - This summary is correct. Please place my new order.");
                Console.WriteLine("2. NO - This summary is not correct.");
                string answer = Console.ReadLine().ToUpper();

                if (answer == "1" || answer == "Y" || answer == "YES")
                {
                    Console.Clear();
                    string s = "***YOUR NEW ORDER WAS SUCCESSFULLY PLACED!***";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.WriteLine(
                        "\nPlease keep track of the date and number order of your order.\nYou will need these to request a search for your order.");
                    Console.WriteLine($"\nDATE: {order.OrderDate}");
                    Console.WriteLine($"ORDER NUMBER: {order.OrderNumber}");
                    Console.WriteLine("\nPress ANY KEY to return to the main menu!");
                    Console.ReadKey();
                    Console.Clear();
                    isValid = true;
                    break;
                }
                else if (answer == "2" || answer == "N" || answer == "NO")
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Would you like to return to the main menu?\n");
                        Console.WriteLine("1. YES - Cancel the order completely and return to the main menu.");
                        Console.WriteLine("2. NO - I would like to try and place a new order again.");
                        string input = Console.ReadLine();

                        if (input == "1" || input == "Y" || input == "YES")
                        {
                            Console.Clear();
                            string s = "***Press ANY KEY to return to the main menu!***";
                            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                            Console.WriteLine(s);
                            Console.ReadKey();
                            Console.Clear();
                            isValid = true;
                        }
                        else if (input == "2" || input == "N" || input == "NO")
                        {
                            CreateOrderWorkflow orderAgain = new CreateOrderWorkflow();
                            orderAgain.Excecute();
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("\nThat wasn't a valid input!");
                            Console.WriteLine("Press ANY KEY to try again!");
                            Console.ReadKey();
                            isValid = false;
                        }
                    } while (!isValid);
                }
                else
                {
                    Console.WriteLine("\nThat wasn't a valid input!");
                    Console.WriteLine("Press ANY KEY to try again!");
                    Console.ReadKey();
                    isValid = false;
                }
            } while (!isValid);
        }

        private void RequestForExistingOrderEdit(Order order)
        {
            EditOrderWorkflow edit = new EditOrderWorkflow();
            bool isValid = true;

            do
            {
                Console.WriteLine("\nWould you like to make any edits to this order?\n");
                Console.WriteLine("1. YES");
                Console.WriteLine("2. NO");
                string answer = Console.ReadLine().ToUpper();

                if (answer == "1" || answer == "Y" || answer == "YES")
                {
                    edit.InSummaryExecute(order);
                    isValid = true;
                    break;
                }
                else if (answer == "2" || answer == "N" || answer == "NO")
                {
                    Console.Clear();
                    string s = "***Press ANY KEY to return to the main menu!***";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.ReadKey();
                    Console.Clear();
                    isValid = true;

                }
                else
                {
                    Console.WriteLine("\nThat wasn't a valid input!");
                    Console.WriteLine("Press ANY KEY to try again!");
                    Console.ReadKey();
                    isValid = false;
                }
            } while (!isValid);
        }
    }
}
