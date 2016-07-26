using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data.ProductsRepo
{
    public class ProductsFileRepo : ProductRepository
    {
        private const string FILENAME = @"C:\Users\Apprentice\Desktop\_Repository\jeannine-james-individual-work\FlooringProgram\FlooringProgram.Data\ProductsRepo\Products.txt";

        static ProductsFileRepo()
        {
            using (StreamReader sr = File.OpenText(FILENAME))
            {
                string inputLine = "";
                string[] inputParts;

                while ((inputLine = sr.ReadLine()) != null)
                {
                    inputParts = inputLine.Split(',');
                    Product thisProduct = new Product()
                    {
                        Type = inputParts[0],
                        MaterialCost = decimal.Parse(inputParts[1]),
                        LaborCost = decimal.Parse(inputParts[2]),
                        
                    };

                    ProductList.Add(thisProduct);
                }
            }
        }
    }
}