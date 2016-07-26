using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data.OrdersRepo
{
    public abstract class OrderRepository
    {
        //public static Dictionary<int, Order> OrdersList { get; private set; }
        public static List<Order> OrdersList { get; private set; }

        // default constructor to initialize our list of orders
        static OrderRepository()
        {
          //  OrdersList = new Dictionary<int, Order>();
            OrdersList = new List<Order>();
        }

        // method to get the order by the order number
        // DISPLAY
        public abstract Order GetOrderByDateAndNum(string date, int ordNum);
       
        // method to add a new order to the order list
        // ADD
        public virtual Order CreateNewOrder(Order order)
        {
            OrdersList.Add(order);
            return order;
        }

        public int GetNextOrderNumber()
        {
            int orderNumber = 0;


            if (OrdersList.Count != 0)
            {
                var nextNum = OrdersList.Max(o => o.OrderNumber);
                orderNumber = nextNum;
            }
            else
            {
                orderNumber = 0;
            }

            //if (OrdersList.Count != 0)
            //{
            //    orderNumber = OrdersList.;
            //}
            return ++orderNumber;
        }

        // Edit an existing order
        // EDIT
        public abstract bool Edit(Order order, Order editedOrder);

        // delete an order from the list
        // REMOVE
        public abstract void Remove(Order order);

        public virtual void ListAllOrdersInRepo()
        {
            foreach (var o in OrdersList)
            {
                Console.WriteLine($"ORDER NUMBER: {o.OrderNumber}");
                Console.WriteLine($"ORDER DATE: {o.OrderDate}");
                Console.WriteLine($"CUSTOMER NAME: {o.CustomerName}");
                Console.WriteLine($"FULL STATE NAME: {o.State.StateName}");
                Console.WriteLine($"STATE ABBREVIATION: {o.State.StateAbbreviation}");
                Console.WriteLine($"PRODUCT TYPE: {o.ProductType.Type}");
                Console.WriteLine($"AREA REQUESTED: {o.Area} SQ FT");
                Console.WriteLine($"PRODUCT MATERIAL COST/SQ FT: {o.ProductType.MaterialCost}");
                Console.WriteLine($"PRODUCT LABOR COST/SQ FT: {o.ProductType.LaborCost}");
                Console.WriteLine($"TOTAL COST OF ORDER: {o.PriceTotal.ToString("C", CultureInfo.CurrentCulture)}");
                Console.WriteLine();

            }
        }
    }
}
