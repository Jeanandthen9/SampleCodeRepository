using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;

namespace FlooringProgram.UI.Workflows
{
    public class EditOrderWorkflow
    {
        
        public void Execute()
        {
            OrderSearchWorkflow search = new OrderSearchWorkflow();
            search.Execute();
        }

        public void InSummaryExecute(Order order)
        {
            ChooseField(order);
        }

        private void ChooseField(Order order)
        {
            
            bool isValid = true;
            string newName;


            var originalOrder = order;

            Order editedOrder = new Order()
            {
                OrderNumber = order.OrderNumber,
                CustomerName = order.CustomerName,
                State = order.State,
                ProductType = order.ProductType,
                Area = order.Area,
                PriceTotal = ((order.ProductType.LaborCost * order.Area) + (order.ProductType.MaterialCost * order.Area)) * order.State.TaxRate,
                OrderDate = order.OrderDate
            };

            do
            {
                Console.WriteLine("\nWhich field would you like to edit?\n");
                Console.WriteLine("1. NAME");
                Console.WriteLine("2. STATE");
                Console.WriteLine("3. PRODUCT TYPE");
                Console.WriteLine("4. AREA");
                Console.WriteLine("***NOTE*** IF YOU LEAVE THE FIELD BLANK, NO CHANGES WILL BE MADE TO THE ORDER.\n");
                string choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    #region CHANGE NAME
                    case "1":
                        Console.Clear();
                        newName = GetName(editedOrder);
                        if (String.IsNullOrWhiteSpace(newName))
                        {
                            editedOrder.CustomerName = originalOrder.CustomerName;
                            ProcessEditedInfo(editedOrder);
                        }
                        else
                        {
                            editedOrder.CustomerName = newName;
                            ProcessEditedInfo(editedOrder);
                        }
                        isValid = true;
                        break;
                    #endregion

                    #region CHANGE STATE
                    case "2":
                        Console.Clear();
                        GetState(editedOrder);
                        isValid = true;
                        break;
                    #endregion

                    #region CHANGE PRODUCT
                    case "3":
                        Console.Clear();
                        GetProductType(editedOrder);
                        isValid = true;
                        break;
                    #endregion

                    #region CHANGE AREA
                    case "4":
                        Console.Clear();
                        GetArea(editedOrder);
                        isValid = true;
                        break;
                    #endregion

                    #region INVALID ENTRY
                    default:
                        Console.WriteLine("\nThat wasn't a valid entry!");
                        Console.WriteLine("Press ANY KEY to try again!");
                        isValid = false;
                        break;
                    #endregion
                }
            } while (!isValid);
        }

        private string GetName(Order originalOrder)
        {
            string s = "***EDITING ORDER***\n";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            string name;
            Console.WriteLine($"ORIGINAL NAME: {originalOrder.CustomerName}");
            Console.Write($"EDITED NAME: ");
            name = Console.ReadLine();
            return name;
        }

        private void GetState(Order originalOrder)
        {
            bool isValid = true;
            string getStateInput;
            State originalState = originalOrder.State;
            State editedState;
            OrderProcessing request = new OrderProcessing();

            do
            {
                string s = "***EDITING ORDER***\n";
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
                Console.WriteLine($"ORIGINAL STATE (FULL STATE NAME): {originalOrder.State.StateName}");
                Console.Write($"EDITED STATE (FULL STATE NAME): ");
                getStateInput = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(getStateInput))
                {
                    originalOrder.State = originalState;
                    ProcessEditedInfo(originalOrder);
                    isValid = true;
                }
                else
                {
                    editedState = request.GetStateTaxesFromRepo(getStateInput);

                    if (editedState == null)
                    {
                        Console.WriteLine("\nThat state does not exist within the database!");
                        Console.WriteLine("Press ANY KEY to try again!");
                        Console.ReadKey();
                        Console.Clear();
                        isValid = false;
                    }
                    else
                    {
                        originalOrder.State = editedState;
                        ProcessEditedInfo(originalOrder);
                        isValid = true;
                    }
                }
            } while (!isValid);
        }

        private void GetProductType(Order originalOrder)
        {
            bool isValid = true;
            string productType;
            Product originalProduct = originalOrder.ProductType;
            Product editedProduct;
            OrderProcessing request = new OrderProcessing();

            do
            {
                string s = "***EDITING ORDER***\n";
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
                Console.WriteLine($"ORIGINAL PRODUCT TYPE: {originalOrder.ProductType.Type}");
                Console.Write($"EDITED PRODUCT TYPE: ");
                productType = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(productType))
                {
                    originalOrder.ProductType = originalProduct;
                    ProcessEditedInfo(originalOrder);
                    isValid = true;
                }
                else
                {
                    editedProduct = request.GetProductFromRepo(productType);

                    if (editedProduct == null)
                    {
                        Console.WriteLine("\nThat product does not exist within the database!");
                        Console.WriteLine("Press ANY KEY to try again!");
                        Console.ReadKey();
                        Console.Clear();
                        isValid = false;
                    }
                    else
                    {
                        originalOrder.ProductType = editedProduct;
                        ProcessEditedInfo(originalOrder);
                        isValid = true;
                    }
                }
            } while (!isValid);
        }

        private void GetArea(Order originalOrder)
        {
            bool isValid = true;
            string area;
            decimal expected;

            do
            {
                string s = "***EDITING ORDER***\n";
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
                Console.WriteLine($"ORIGINAL TOTAL AREA (PER SQUARE FOOT): {originalOrder.Area}");
                Console.Write($"EDITED TOTAL AREA (PER SQUARE FOOT): ");
                area = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(area))
                {
                    originalOrder.Area = originalOrder.Area;
                    ProcessEditedInfo(originalOrder);
                    isValid = true;
                }

                else
                {
                    if (decimal.TryParse(area, out expected) == false)
                    {
                        Console.WriteLine("\nThat was not a valid entry!");
                        Console.WriteLine("Press ANY KEY to try again!");
                        Console.ReadKey();
                        Console.Clear();
                        isValid = false;
                    }
                    else
                    {
                        originalOrder.Area = expected;
                        ProcessEditedInfo(originalOrder);
                        isValid = true;
                    }
                }
            } while (!isValid);
        }

        private void ProcessEditedInfo(Order editedOrder)
        {
            OrderProcessing request = new OrderProcessing();
            Response response = request.EditExistingOrder(editedOrder);

            if (response.Success == true)
            {
                Console.Clear();
                OrderSummaryWorkflow summary = new OrderSummaryWorkflow();
                string r = "************************************";
                string s = "***SUCCESSFULLY EDITED THE ORDER!***";
                string t = "************************************\n";
                Console.SetCursorPosition((Console.WindowWidth - r.Length) / 2, Console.CursorTop);
                Console.WriteLine(r);
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
                Console.SetCursorPosition((Console.WindowWidth - t.Length) / 2, Console.CursorTop);
                Console.WriteLine(t);
                summary.ExecuteEditedOrderSummary(editedOrder);
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
