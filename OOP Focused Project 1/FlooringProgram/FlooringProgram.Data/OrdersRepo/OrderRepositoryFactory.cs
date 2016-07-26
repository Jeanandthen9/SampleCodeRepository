using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FlooringProgram.Data.OrdersRepo
{
    public static class OrderRepositoryFactory
    {
        public static OrderRepository CreateOrderRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            OrderRepository repo;

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new OrdersMockRepo();
                    break;
                case "PROD":
                    repo = new OrdersFileRepo();
                    break;
                default:
                    throw new Exception("That mode doesn't exist!");
            }
          
            return repo;
        }
    }
}
