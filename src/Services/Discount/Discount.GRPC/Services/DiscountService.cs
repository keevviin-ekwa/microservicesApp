using AutoMapper;
using Discount.GRPC.Entities;
using Discount.GRPC.Protos;
using Discount.GRPC.Repositories;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Discount.GRPC.Services
{
    public class DiscountService: DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository discountRepository;
        private readonly ILogger<DiscountService> logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository discountRepository, ILogger<DiscountService> logger, IMapper mapper)
        {
            this.discountRepository = discountRepository;
            this.logger = logger;
            _mapper = mapper;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await discountRepository.GetDiscount(request.ProductName);
            if(coupon == null)
            {  
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName}  is not found"));
            }
            logger.LogInformation("Discount is sucessfully Retreived. ProductName : {ProductName}", coupon.ProductName);
            var couponModel=_mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
         
            await discountRepository.CreateDiscount(coupon);
            logger.LogInformation("Discount is sucessfully created. ProductName : {ProductName}", coupon.ProductName);
            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }


        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            await discountRepository.UpdateDiscount(coupon);
            logger.LogInformation("Discount is sucessfully updated. ProductName : {ProductName}", coupon.ProductName);
            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<DeleteDiscountResponse> DeleDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleted = await discountRepository.DeleteDiscount(request.ProductName);
            var response = new DeleteDiscountResponse
            {
                Success = deleted
            };

            return response;
        }



    }
}
