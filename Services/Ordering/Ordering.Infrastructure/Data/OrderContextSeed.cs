using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("ordering Database Seeding");

            }
        }
        public static IEnumerable<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    UserName="mahmodudSalama",
                    EmailAddress="Mahmoud222Salama@gmail.com",
                    AddressLine="Egypt",
                    Country="Egypt",
                    TotalPrice=100,
                    FirstName="Mahmoud",
                    LastName="Salama",
                    state="EG",
                    Zibcode="123456",
                    CardName="Visa",
                    CardNumber="123456789101112",
                    Cvv="123",
                    CreatedBy="Mahmoud",
                    Expiration="12/26",
                    LastModifiedBy="Mahmoud",
                    PaymentMethod=1,
                    LastModifiedDate=new DateTime()


                }
            };
        }
    }
}
