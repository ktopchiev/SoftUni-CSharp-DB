using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos
{
    public class SoldProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string BuyerFirstName { get; set; }

        public string BuyerLastName { get; set; }
    }
}
