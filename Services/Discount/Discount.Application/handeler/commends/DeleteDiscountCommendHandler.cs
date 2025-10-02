using AutoMapper;
using Discount.Application.commends;
using Discount.Core.Entities;
using Discount.Core.Repositries;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Catalog.Application.handeler.commends
{
    public class DeleteDiscountCommendHandler : IRequestHandler<DeleteCouponCommend, bool>
    {


        private readonly IMapper _mapper;
        private readonly IDiscountRepository discountRepository;




        public DeleteDiscountCommendHandler(IMapper Mapper, IDiscountRepository discountRepository)
        {
            _mapper = Mapper;
            this.discountRepository = discountRepository;


        }
        public async Task<bool> Handle(DeleteCouponCommend request, CancellationToken cancellationToken)
        {



            var deleteCoupon = await discountRepository.DeleteDiscount(request.ProductName);
            if (!deleteCoupon)
            {
                throw new RpcException(new Status(StatusCode.Internal, "Discount Not Delete"));

            }

            return deleteCoupon;

        }
    }
}
