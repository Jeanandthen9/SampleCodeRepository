using System;
using System.Globalization;
using System.IO;
using System.Linq;
using FlooringProgram.Models;

namespace FlooringProgram.Data.OrdersRepo
{
    public class OrdersFileRepo : OrderRepository
    {
        private const string FILENAME = @"DataFiles\Orders_";
        private const string FILEEXT = ".txt";

        static OrdersFileRepo()
        {
            // need to iterate ALL ORDER FILES to make it work
            // OR load on demand
            // USE A LOOP!!
            using (StreamReader sr = File.OpenText(FILENAME))
            {
                string inputLine = "";
                string[] inputParts;

                while ((inputLine = sr.ReadLine()) != null)
                {
                    inputParts = inputLine.Split('|');
                    Order thisOrder = new Order()
                    {
                        OrderNumber = int.Parse(inputParts[0]),
                        OrderDate = inputParts[1],
                        CustomerName = inputParts[2],
                        State = new State()
                        {
                            StateAbbreviation = inputParts[3],
                            StateName = inputParts[4],
                            TaxRate = decimal.Parse(inputParts[5]),
                        },
                        ProductType = new Product()
                        {
                            Type = inputParts[6],
                            LaborCost = decimal.Parse(inputParts[7]),
                            MaterialCost = decimal.Parse(inputParts[8])
                        },
                        Area = decimal.Parse(inputParts[9]),
                        PriceTotal = decimal.Parse(inputParts[10])
                    };
                    OrdersList.Add(thisOrder);
                }
            }
        }

        public override Order CreateNewOrder(Order order)
        {
            base.CreateNewOrder(order);
            string filename = FILENAME + DateTime.Parse(order.OrderDate).ToString("MMddyyyy") + FILEEXT;
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                foreach (var o in OrdersList)
                {
                    sw.WriteLine($"{o.OrderNumber}|{o.OrderDate}|{o.CustomerName}|{o.State.StateAbbreviation}|{o.State.StateName}|{o.State.TaxRate}|{o.ProductType.Type}|{o.ProductType.LaborCost}|{o.ProductType.MaterialCost}|{o.Area}|{o.PriceTotal}");
                    //sw.WriteLine($"{o.OrderNumber}|{o.OrderDate}|{o.CustomerName}|{o.FullStateName}|{o.ProductName}|{o.Area}|{o.PriceTotal}");
                }
            }
            return order;
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

        public override bool Edit(Order originalOrder, Order editedOrder)
        {
            
            string originalDate = originalOrder.OrderDate;
            int originalNum = originalOrder.OrderNumber;

            var list = from o in OrdersList
                select o;

            bool isValid = true;

            foreach (var o in list)
            {
                if (o.OrderDate == originalDate && o.OrderNumber == originalNum)
                {
                    Order currentOrder = o;

                    currentOrder.OrderDate = originalDate;
                    currentOrder.Area = editedOrder.Area;
                    currentOrder.CustomerName = editedOrder.CustomerName;
                    currentOrder.OrderNumber = originalNum;
                    currentOrder.PriceTotal = editedOrder.PriceTotal;
                    currentOrder.ProductType = editedOrder.ProductType;
                    currentOrder.State = editedOrder.State;

                    string filename = FILENAME + DateTime.Parse(currentOrder.OrderDate).ToString("MMddyyyy") + FILEEXT;
                    using (StreamWriter sw = new StreamWriter(filename, false))
                    {
                        foreach (var l in OrdersList)
                        {
                            sw.WriteLine(
                                $"{l.OrderNumber}|{l.OrderDate}|{l.CustomerName}|{l.State.StateAbbreviation}|{l.State.StateName}|{l.State.TaxRate}|{l.ProductType.Type}|{l.ProductType.LaborCost}|{l.ProductType.MaterialCost}|{l.Area}|{l.PriceTotal}");
                            //sw.WriteLine($"{o.OrderNumber}|{o.OrderDate}|{o.CustomerName}|{o.FullStateName}|{o.ProductName}|{o.Area}|{o.PriceTotal}");
                            //sw.WriteLine($"{o.OrderNumber}|{o.OrderDate}|{o.CustomerName}|{o.StateAbbreviation}|{o.ProductName}|{o.PriceTotal}");
                        }
                    }   
                    isValid = true;
                    break;
                }
                else
                {
                    isValid = false;
                }          
            }
            return isValid;
        }

        public override void Remove(Order order)
        {

            if (OrdersList.Contains(order))
            {
                OrdersList.Remove(order);

                string filename = FILENAME + DateTime.Parse(order.OrderDate).ToString("MMddyyyy") + FILEEXT;
                using (StreamWriter sw = new StreamWriter(filename, false))
                {
                    foreach (var o in OrdersList)
                    {
                        sw.WriteLine($"{o.OrderNumber}|{o.OrderDate}|{o.CustomerName}|{o.State.StateAbbreviation}|{o.State.StateName}|{o.State.TaxRate}|{o.ProductType.Type}|{o.ProductType.LaborCost}|{o.ProductType.MaterialCost}|{o.Area}|{o.PriceTotal}");
                        //sw.WriteLine($"{o.OrderNumber}|{o.OrderDate}|{o.CustomerName}|{o.FullStateName}|{o.ProductName}|{o.Area}|{o.PriceTotal}");
                        //sw.WriteLine($"{o.OrderNumber}|{o.OrderDate}|{o.CustomerName}|{o.StateAbbreviation}|{o.ProductName}|{o.PriceTotal}");
                    }
                }
            }
        }
    }
}
