using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Data
{
    public static class DbExtenshion
    {
        public static IHost MigrateDarabase<Tcontext>(this IHost host)
        {
            // إنشاء نطاق (Scope) جديد للخدمات
            //معناها "اعمل نطاق خدمات جديد" بحيث أي خدمة Scoped يتم إنشاؤها داخل هذا النطاق ويتم التخلص منها تلقائيًا عند انتهاء الـ using.

            using var scope = host.Services.CreateScope();
            //  ده هو المسئول عن إعطائك إمكانية الوصول لكل الخدمات اللي مسجّلة في الـ DI.
            var services = scope.ServiceProvider; // الحصول على كائن الـ ServiceProvider الخاص بالنطاق
            var cofig = services.GetRequiredService<IConfiguration>(); // اوimplention  جلب خدمة IConfiguration من الـ DI
            var logger = services.GetRequiredService<ILogger<Tcontext>>();
            try
            {
                logger.LogInformation("Discount DB Migration");
                AppLyMigration(cofig);
                logger.LogInformation("Discount DB Migration Completed");

            }
            catch (Exception ex)
            {
                logger.LogInformation("Cant Create DB Migration");
                throw;

            }
            return host;

        }

        private static void AppLyMigration(IConfiguration config)
        {

            var retry = 5;
            while (retry > 0)
            {
                try
                {
                    var connectionString = config.GetSection("DatabaseSettings")["ConnectionString"];

                    if (string.IsNullOrEmpty(connectionString))
                    {
                        Console.WriteLine("⚠️ Connection string is missing!");
                        throw new InvalidOperationException("Connection string is not configured properly.");
                    }

                    using var connection = new NpgsqlConnection(connectionString);
                    connection.Open();
                    using var cmd = new NpgsqlCommand
                    {
                        Connection = connection,


                    };
                    cmd.CommandText = "DROP TABLE IF EXISTS COUPON";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"
                        CREATE TABLE COUPON(
                            ID SERIAL PRIMARY KEY,
                            ProductName VARCHAR(500) NOT NULL,
                            Description TEXT,
                            Amount INT
                        )";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"
                            INSERT INTO COUPON (ProductName, Description, Amount)
                            VALUES 
                            ('Test Product 1', 'Description for Product 1', 100),
                            ('Test Product 2', 'Description for Product 2', 200)";
                    cmd.ExecuteNonQuery();

                    break; // Exit loop if success
                }
                catch (Exception ex)
                {
                    retry--;
                    if (retry == 0)
                    {
                        throw; // rethrow if retries exhausted
                    }

                    Console.WriteLine($"Migration failed, retries left: {retry}, Error: {ex.Message}");
                    System.Threading.Thread.Sleep(2000); // wait before retry
                }


            }




        }



    }
}
