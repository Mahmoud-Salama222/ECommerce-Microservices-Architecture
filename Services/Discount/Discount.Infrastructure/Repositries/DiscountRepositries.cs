using Dapper;
using Discount.Core.Entities;
using Discount.Core.Repositries;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Repositries
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Coupon> CreateCoupon(Coupon coupon)
        {
            var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");

            await using var connection = new NpgsqlConnection(connectionString);

            var sql = @"INSERT INTO Coupon (ProductName, Description, Amount) 
                VALUES (@ProductName, @Description, @Amount)";

            var id = await connection.ExecuteScalarAsync<int>(sql, new
            {
                coupon.ProductName,
                coupon.Description,
                coupon.Amount
            });

            // تحديث الـ Id داخل الكائن قبل الإرجاع
            coupon.Id = id;

            return coupon;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            await using var connection = new NpgsqlConnection(connectionString);

            var sql = "DELETE FROM Coupon WHERE ProductName = @ProductName";

            var rowsAffected = await connection.ExecuteAsync(sql, new { ProductName = productName });

            return rowsAffected > 0;




        }

        public async Task<Coupon> GetDiscount(string proudctName)
        {
            await using var connection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(
                "SELECT * FROM Coupon WHERE ProductName = @ProductName",
                new { ProductName = proudctName } // ← هنا التعديل
            );

            if (coupon == null)
            {
                return new Coupon { Amount = 0, Description = "No Discount Are Avalabile for this proudct", ProductName = proudctName };
            }
            return coupon;

        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            await using var connection = new NpgsqlConnection(connectionString);


            var sql = @"
                UPDATE Coupon
                SET ProductName = @ProductName,
                    Description = @Description,
                    Amount = @Amount
                WHERE Id = @Id";

            var rowsAffected = await connection.ExecuteAsync(sql, new
            {
                coupon.ProductName,
                coupon.Description,
                coupon.Amount,
                coupon.Id
            });
            return rowsAffected > 0;

        }
    }
}
