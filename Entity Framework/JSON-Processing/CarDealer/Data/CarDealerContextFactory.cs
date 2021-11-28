using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarDealer.Data
{
    public class CarDealerContextFactory : IDesignTimeDbContextFactory<CarDealerContext>
    {
        public CarDealerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarDealerContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=CarDealer;Trusted_Connection=True;");

            return new CarDealerContext(optionsBuilder.Options);
        }
    }
}
