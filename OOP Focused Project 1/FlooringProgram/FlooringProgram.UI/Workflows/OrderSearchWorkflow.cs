﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;

namespace FlooringProgram.UI.Workflows
{
    public class OrderSearchWorkflow
    {
        public void Execute()
        {
            bool isValid = true;
            bool redo = true;
            do
            {
                string date = GetDate();
                int num = GetOrderNum();
                do
                {
                    Console.Clear();
                    string s = "***PLEASE REVIEW***\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.WriteLine($"DATE: {date}");
                    Console.WriteLine($"ORDER NUMBER: {num}");

                    Console.WriteLine("\nIs this information correct?\n");
                    Console.WriteLine("1. YES - This information is correct.");
                    Console.WriteLine("2. NO - There's some errors. I would like to start over.");
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == "1" || answer == "Y" || answer == "YES")
                    {
                        Console.Clear();
                        ProcessSearch(date, num);
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

        private string GetDate()
        {

            bool isValid = true;
            string date;
            DateTime convertDate;

            do
            {
                string s = "***SEARCHING FOR ORDER***\n";
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
                Console.WriteLine("Please enter the date and order number of your order:\n");
                Console.Write($"DATE (IN MM/DD/YYYY FORMAT, IE: 05/30/2016): ");
                date = Console.ReadLine();
                if (!DateTime.TryParseExact(date, "MM/dd/yyyy", null, DateTimeStyles.None, out convertDate))
                {
                    Console.WriteLine("\nThat is not a valid date format!");
                    Console.WriteLine("Press ANY KEY to try again!");
                    Console.ReadKey();
                    Console.Clear();
                    isValid = false;
                }
                else if (!String.IsNullOrWhiteSpace(date))
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
            return date;
        }

        private int GetOrderNum()
        {
            bool isValid = true;
            string orderNum;
            int num;

            do
            {
                string s = "***SEARCHING FOR ORDER***\n";
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
                Console.WriteLine("Please enter the date and order number of your order:\n");
                Console.Write($"ORDER NUMBER: ");
                orderNum = Console.ReadLine();
                
                int.TryParse(orderNum, out num);
                if (int.TryParse(orderNum, out num) == false || num < 1)
                {
                    Console.WriteLine("\nThat wasn't a valid entry!");
                    Console.WriteLine("Please enter a POSITIVE INTEGER (ie: 1, 2, 3...).");
                    Console.WriteLine("Press ANY KEY to try again!");
                    Console.ReadKey();
                    Console.Clear();
                    isValid = false;
                }
                else if (!String.IsNullOrWhiteSpace(orderNum))
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
            return num;
        }

        private void ProcessSearch(string date, int num)
        {
            OrderProcessing request = new OrderProcessing();
            Response response = request.SearchForOrder(date, num);

            if (response.Success)
            {
                OrderSummaryWorkflow summary = new OrderSummaryWorkflow();
                summary.ExecuteExistingOrderSummary(response.OrderInfo);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine("Press ANY KEY to return to the main menu!");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
