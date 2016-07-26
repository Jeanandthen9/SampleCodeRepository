using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data.ProductsRepo
{
    public abstract class ProductRepository
    {
        //protected static Dictionary<int, Product> ProductsList { get; private set; }
        //protected static Dictionary<string, Product> ProductList { get; private set; }
        protected static List<Product> ProductList { get; private set; }

        static ProductRepository()
        {
            ProductList = new List<Product>();
        }

        //public virtual Product GetProductByNum(int prodNum)
        //{
        //    Product product = null;

        //    if (ProductsList.ContainsKey(prodNum))
        //    {
        //        product = ProductsList[prodNum];
        //    }
        //    return product;
        //}

        public virtual Product GetProductByName(string prodName)
        {
            Product product = null;

            var list = from p in ProductList
                where p.Type.Equals(prodName, StringComparison.InvariantCultureIgnoreCase)
                select p;

            foreach (var p in list)
            {
                product = p;
            }
            
            return product;
        }
    }
}
