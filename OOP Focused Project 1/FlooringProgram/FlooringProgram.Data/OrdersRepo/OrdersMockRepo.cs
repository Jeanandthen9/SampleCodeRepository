using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data.OrdersRepo;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class OrdersMockRepo : OrderRepository
    {

        static OrdersMockRepo()
        {
            OrdersList.Add(
                new Order
                {
                    Area = 90.5m,
                    OrderDate = "07/05/2016",
                    OrderNumber = 4,
                    CustomerName = "Dio Brando",
                    State = new State()
                    {
                        StateAbbreviation = "OH",
                        StateName = "Ohio".ToUpper(),
                        TaxRate = 0.0625m
                    },
                    ProductType = new Product()
                    {
                      LaborCost  = 2.10m,
                      MaterialCost = 2.25m,
                      Type = "Carpet".ToUpper()
                    },
                    PriceTotal = (((2.10m * 90.5m) + (2.25m * 90.5m)) / 0.0625m)
                });
            OrdersList.Add(
                new Order
                {
                    Area = 10.75m,
                    OrderDate = "07/05/2016",
                    OrderNumber = 5,
                    CustomerName = "Jotaro Kujo",
                    State = new State()
                    {
                        StateAbbreviation = "PA",
                        StateName = "Pennsylvania".ToUpper(),
                        TaxRate = 0.0675m
                    },
                    ProductType = new Product()
                    {
                      LaborCost  = 2.10m,
                      MaterialCost = 1.75m,
                      Type = "Laminate".ToUpper()
                    },
                    PriceTotal = (((1.75m*10.75m) + (2.10m*10.75m)) / 0.0675m)
                });
            OrdersList.Add(
                new Order
                {
                    Area = 90.5m,
                    OrderDate = "07/07/2016",
                    OrderNumber = 15,
                    CustomerName = "Joseph Joestar",
                    State = new State()
                    {
                        StateAbbreviation = "MI",
                        StateName = "Michigan".ToUpper(),
                        TaxRate = 0.0575m
                    },
                    ProductType = new Product()
                    {
                      Type  = "Tile".ToUpper(),
                      MaterialCost = 3.50m,
                      LaborCost = 4.15m
                    },
                    PriceTotal = (((90.5m*3.50m) + (90.5m*4.15m)) / 0.0575m)
                });
        }

        public override Order GetOrderByDateAndNum(string date, int ordNum)
        {
            Order order = null;

            var list = from o in OrdersList
                where o.OrderNumber == ordNum && o.OrderDate == date
                select o;

            foreach (var o in list)
            {
                order = o;
            }

            return order;
        }

        public override Order CreateNewOrder(Order order)
        {
            OrdersList.Add(order);
            return order;
        }

        public override bool Edit(Order order, Order editedOrder)
        {
            bool isValid = false;

            if (OrdersList.Contains(order))
            {
                OrdersList[order.OrderNumber] = order;

                isValid = true;
            }
            return isValid;
        }

        public override void Remove(Order order)
        {
            if (OrdersList.Contains(order))
            {
                OrdersList.Remove(order);
            }
        }
    }
}
