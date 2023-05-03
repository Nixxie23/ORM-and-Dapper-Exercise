using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class Product
    {
        public int productId { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int categoryId { get; set; }
        public bool onSale { get; set; }
        public int stockLevel { get; set; }
    }
}
