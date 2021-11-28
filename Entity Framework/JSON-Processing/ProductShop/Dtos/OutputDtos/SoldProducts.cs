using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.OutputDtos
{
    public class SoldProducts
    {
        public int Count { get; set; }

        public IEnumerable<ProductDto> Products { get; set;}
    }
}
