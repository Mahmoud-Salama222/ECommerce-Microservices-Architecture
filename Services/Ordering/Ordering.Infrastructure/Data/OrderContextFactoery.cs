using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextFactoery : IDesignTimeDbContextFactory<OrderContext>
    {
        public OrderContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<OrderContext>();
            optionBuilder.UseSqlServer("Server=localhost;Database=OrderDb2 ; User Id=sa;Password=P@ssw0rd123;TrustCertificate=True;");
            return new OrderContext(optionBuilder.Options);
        }
    }
}
