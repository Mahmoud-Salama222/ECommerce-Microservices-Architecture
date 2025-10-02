using Discount.Grpc.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountGrpcService;
        private readonly ILogger<DiscountGrpcService> _logger;
        public DiscountGrpcService(ILogger<DiscountGrpcService> logger, DiscountProtoService.DiscountProtoServiceClient _discountGrpcService)
        {
            this._discountGrpcService = _discountGrpcService;
            _logger = logger;
        }
        public async Task<CouponModel> GetDiscount(string productName)
        {
            try
            {
                _logger.LogInformation("Calling Discount gRPC service for product: {ProductName}", productName);

                var discountRequest = new GetDiscountRequest { ProductName = productName };
                var discount = await _discountGrpcService.GetDiscountAsync(discountRequest);

                _logger.LogInformation("Successfully received discount for product: {ProductName} - Amount: {Amount}",
                    productName, discount.Amount);

                return discount;
            }
            catch (Grpc.Core.RpcException ex)
            {
                _logger.LogError(ex,
                    "gRPC call failed. Status: {Status}, Detail: {Detail}",
                    ex.Status.StatusCode, ex.Status.Detail);

                throw; // نرمي الخطأ عشان يظهر في الـ API
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Unexpected error occurred while calling Discount gRPC service for product: {ProductName}",
                    productName);

                throw;
            }
        }
    }
}

