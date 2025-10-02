using Discount.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Core.Repositries
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productName);
        Task<Coupon> CreateCoupon(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productName);



    }
}
