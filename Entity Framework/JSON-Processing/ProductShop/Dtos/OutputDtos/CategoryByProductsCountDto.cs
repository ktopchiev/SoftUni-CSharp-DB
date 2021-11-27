using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.OutputDtos
{
    public class CategoryByProductsCountDto
    {
        public string Category { get; set; }

        public int ProductsCount { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
