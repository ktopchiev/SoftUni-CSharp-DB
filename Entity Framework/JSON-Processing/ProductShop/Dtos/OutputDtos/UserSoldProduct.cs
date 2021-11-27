using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.OutputDtos
{
    public class UserSoldProduct
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<SoldProduct> SoldProducts { get; set; }
    }
}
