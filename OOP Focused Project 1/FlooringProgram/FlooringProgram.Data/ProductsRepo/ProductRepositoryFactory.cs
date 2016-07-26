using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FlooringProgram.Data.ProductsRepo
{
    public static class ProductRepositoryFactory
    {
        public static ProductRepository CreateProdRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            ProductRepository repo;

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new ProductsMockRepo();
                    break;
                case "PROD":
                    repo = new ProductsFileRepo();
                    break;
                default:
                    throw new Exception("That mode doesn't exist!");
            }
            return repo;
        }
    }
}
