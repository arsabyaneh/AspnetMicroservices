using Discount.Grpc.Protos;
using System.Threading.Tasks;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly Discount.Grpc.Protos.DiscountGrpcService.DiscountGrpcServiceClient _discountGrpcClient;

        public DiscountGrpcService(Discount.Grpc.Protos.DiscountGrpcService.DiscountGrpcServiceClient discountGrpcClient)
        {
            _discountGrpcClient = discountGrpcClient;
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            return await _discountGrpcClient.GetDiscountAsync(new GetDiscountRequest { ProductName = productName });
        }
    }
}
