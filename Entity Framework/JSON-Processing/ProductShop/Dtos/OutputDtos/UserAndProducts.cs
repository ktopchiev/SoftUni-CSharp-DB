using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.OutputDtos
{
    public class UserAndProducts
    {
        public string LastName { get; set; }

        public int? Age { get; set; }

        public ICollection<SoldProducts> SoldProducts { get; set; }
    }
}
