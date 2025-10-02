using MediatR;

namespace Discount.Application.commends
{
    public class DeleteCouponCommend : IRequest<bool>
    {
        public string ProductName { get; set; }
        public DeleteCouponCommend(string ProductName) //to force send Id when send commend
        {
            this.ProductName = ProductName;
        }
    }
}
