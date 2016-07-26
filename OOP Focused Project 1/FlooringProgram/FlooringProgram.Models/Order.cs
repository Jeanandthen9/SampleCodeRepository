using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class Order
    {
        public string OrderDate { get; set; }
        public string CustomerName { get; set; }
        public Product ProductType { get; set; }
        //public string ProductName { get; set; }
      //  public string StateAbbreviation { get; set; }
      // public string FullStateName { get; set; }
       public State State { get; set; }
        public decimal Area { get; set; }
        public decimal PriceTotal { get; set; }
        public int OrderNumber { get; set; }

    }
}
