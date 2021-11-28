using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.OutputDtos
{
    public class UsersAndProductsDto
    {
        public int UsersCount { get; set; }

        public ICollection<UserAndProducts> Users { get; set; }
    }
}
