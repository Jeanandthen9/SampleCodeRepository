using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data.ProductsRepo
{
    public class ProductsMockRepo : ProductRepository
    {
        //private Dictionary<int, Product> FakeProductList = new Dictionary<int, Product>()
        //{
        //    {1, new Product() {ProductNum = 1, Type = "Wood", LaborCost = 4.00m, MaterialCost = 1.00m} },
        //    {2, new Product() {ProductNum = 2, Type = "Tile", LaborCost = 10.00m, MaterialCost = 5.00m} },
        //    {5, new Product() {ProductNum = 5, Type = "Carpet", LaborCost = 15.00m, MaterialCost = 10.00m} }
        //};

        private Dictionary<string, Product> FakeProductList = new Dictionary<string, Product>()
        {
            {"CARPET", new Product() {Type = "Wood", LaborCost = 2.10m, MaterialCost = 2.25m} },
            {"LAMINATE", new Product() {Type = "Tile", LaborCost = 2.10m, MaterialCost = 1.75m} },
            {"TILE", new Product() {Type = "Tile", LaborCost = 4.15m, MaterialCost = 3.50m} },
            {"WOOD", new Product() {Type = "Wood", MaterialCost = 5.15m, LaborCost = 4.75m} }
        };

        public override Product GetProductByName(string prodName)
        {
            Product product = null;
            if (FakeProductList.ContainsKey(prodName))
            {
                product = FakeProductList[prodName];
            }
            return product;
        }
    }
}
