using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models;
using System.Threading;
using FlooringProgram.Data.OrdersRepo;
using FlooringProgram.Data.ProductsRepo;
using FlooringProgram.Data.TaxesRepo;
using System.IO;
using System.IO.Log;
using FlooringProgram.Data.ErrorLog;

namespace FlooringProgram.BLL
{
    public class OrderProcessing
    {

        public Response AddNewOrder(string customerName, string stateName, string productType, decimal area)
        {
            
            bool isValid = true;
            var response = new Response();
            string missingProd = $"{productType} does not exist within the database as a valid product!\n";
            string missingState = $"{stateName} does not exist within the database as a valid state!\n";

            #region CHECK PRODUCT REPO - Is the user's entered product a valid product within the Product repo?
            Product product = GetProductFromRepo(productType);

            if (product == null)
            {
                response.Success = false;
                response.Message = missingProd;
                ExceptionUtility.LogErrors($"User attempted to CREATE a NEW ORDER. User entered a PRODUCT TYPE of {productType} - Does not exist in database.");
                    
                isValid = false;
            }
            else
            {
                response.Success = true;
            }
            #endregion

            #region CHECK STATE/TAXES REPO - Is the user's entered state a valid product within the Taxes repo?
            State state = GetStateTaxesFromRepo(stateName);

            if (state == null)
            {
                response.Success = false;
                if (!String.IsNullOrEmpty(response.Message))
                {
                    response.Message += "\n";
                }
                response.Message += missingState;
                ExceptionUtility.LogErrors($"User attempted to CREATE a NEW ORDER. User entered a STATE NAME of {stateName} - Does not exist in database.");
                isValid = false;
            }
            else
            {
                response.Success = true;
            }
            #endregion


            #region IF PRODUCT AND STATE EXISTS WITHIN THEIR REPOS, PROCEED TO ADD ORDER
            if (isValid == true)
            {
                var repo = OrderRepositoryFactory.CreateOrderRepo();

                int orderNumber = repo.GetNextOrderNumber();

                Order newOrder = new Order()
                {
                    OrderNumber = orderNumber,
                    CustomerName = customerName,
                    State = state,
                    ProductType = product,
                    Area = area,
                    PriceTotal = ((product.LaborCost*area) + (product.MaterialCost*area))*state.TaxRate,
                    OrderDate = CustomDateTimeFormat(DateTime.Now)
                    
                };

                newOrder = repo.CreateNewOrder(newOrder);
                if (newOrder != null)
                {
                    response.Success = true;
                    response.OrderInfo = newOrder;
                }
                else
                {
                    response.Success = false;
                    response.Message = "There was trouble adding the new order to the database!\n";
                }
            }
            #endregion

            #region IF PRODUCT AND/OR STATE DOES NOT EXIST WITHIN THEIR REPOS, DO NOT ADD ORDER, GIVE ERROR
            else
            {
                response.Success = false;
                response.Message += "The new order WAS NOT created.";
                ExceptionUtility.LogErrors($"The user received the following error(s): {response.Message}");
            }
            #endregion

            return response;
        }

        public Response SearchForOrder(string dateTime, int orderNum)
        {
            var response = new Response();
            var repo = OrderRepositoryFactory.CreateOrderRepo();
            var order = repo.GetOrderByDateAndNum(dateTime, orderNum);

                if (order != null)
                {
                    response.Success = true;
                    response.OrderInfo = order;
                }
                else
                {
                    response.Success = false;
                    response.Message = "We could not find an account with that date and order number!";
                    ExceptionUtility.LogErrors($"User attempted to SEARCH for order using a DATE of {dateTime} and an ORDER NUMBER of {orderNum}. Order could not be found.");
                }

            return response;
        }

        public Response EditExistingOrder(Order editedOrder)
        {
            var response = new Response();
          
            #region IF BOTH PRODUCT AND STATE EXIST, PROCEED TO EDIT THE ORDER

                var repo = OrderRepositoryFactory.CreateOrderRepo();

                Order updatedOrder = new Order()
                {
                    OrderNumber = editedOrder.OrderNumber,
                    CustomerName = editedOrder.CustomerName,
                    State = editedOrder.State,
                    ProductType = editedOrder.ProductType,
                    Area = editedOrder.Area,
                    PriceTotal = ((editedOrder.ProductType.LaborCost * editedOrder.Area) + (editedOrder.ProductType.MaterialCost * editedOrder.Area)) * editedOrder.State.TaxRate,
                    OrderDate = editedOrder.OrderDate
                };

                bool editCheck = repo.Edit(editedOrder, updatedOrder);

                if (editCheck == true)
                {
                    response = SearchForOrder(updatedOrder.OrderDate, updatedOrder.OrderNumber);
                    if (response.Success == false)
                    {
                        response.Message += "Had difficulty locating the account!";
                        ExceptionUtility.LogErrors(
                            $"User attempted to EDIT an EXISTING Order. DATE USED FOR SEARCH: {updatedOrder.OrderDate}. ORDER NUMBER USED FOR SEARCH: {updatedOrder.OrderNumber}. The search for the order FAILED. Order COULD NOT be edited.");

                    }
                    else
                    {
                        response.Success = true;
                    response.OrderInfo = updatedOrder;
                    }
                    
                }
                else
                {
                    response.Success = false;
                    response.Message = "There was trouble getting this order edited!\n";
                    response.Message +=
                        $"Could not edit the order information!";
                    ExceptionUtility.LogErrors(
                        $"User {editedOrder.CustomerName} requested to edit an existing order with DATE {editedOrder.OrderDate} and ORDER NUMBER {editedOrder.OrderNumber}.\nThe requested order cannot be found in the Orders database.\nOrder could not be edited.");
                }
            #endregion

            return response;
        }

        public Response RemoveExistingOrder(string dateTime, int orderNum)
        {
            bool isValid = true;
            Response response = new Response();
            OrderRepository repo = OrderRepositoryFactory.CreateOrderRepo();
            Order order = repo.GetOrderByDateAndNum(dateTime, orderNum);

                    do
                    {
                        Console.WriteLine("\nAre you REALLY sure you want to permanently delete this order?\nOnce deleted, no record of this order will exist!");
                        Console.WriteLine("1. YES - Delete this order.");
                        Console.WriteLine("2. NO - CANCEL");
                        string userChoice = Console.ReadLine().ToUpper();

                        if (userChoice == "1" || userChoice == "YES" || userChoice == "Y")
                        {
                            repo.Remove(order);
                            response.Success = true;
                            isValid = true;
                        }

                        else if (userChoice == "2" || userChoice == "NO" || userChoice == "N")
                        {
                            response.Message = "Order WAS NOT removed from the database!";
                            response.Success = false;
                            isValid = true;
                        }

                        else
                        {
                            Console.WriteLine("That wasn't a valid input!");
                            Console.WriteLine("Press ANY KEY to try again!");
                            Console.ReadKey();
                            Console.Clear();
                            isValid = false;
                            ExceptionUtility.LogErrors($"User expected to input 1, YES, or Y to confirm, or 2, NO, or N to deny. User inputed an invalid entry. User's input: {userChoice}");
                        }
                    } while (!isValid);
            return response;
        }

        private string CustomDateTimeFormat(DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        }

        public Product GetProductFromRepo(string prodName)
        {
            ProductRepository repo = ProductRepositoryFactory.CreateProdRepo();
            Product product = repo.GetProductByName(prodName);

            return product;
        }

        public State GetStateTaxesFromRepo(string stateFullName)
        {
            TaxesRepository repo = TaxesRepositoryFactory.CreateTaxRepo();
            State state = repo.GetStateByFullName(stateFullName);
            return state;
        }
    }
}
