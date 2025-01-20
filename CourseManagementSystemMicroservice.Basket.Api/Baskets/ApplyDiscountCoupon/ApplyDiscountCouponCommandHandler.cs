﻿using CourseManagementSystemMicroservice.Basket.Api.Baskets.Services;
using CourseManagementSystemMicroservice.Basket.Api.Dtos;
using CourseManagementSystemMicroservice.Shared;
using MediatR;
using System.Net;
using System.Text.Json;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.ApplyDiscountCoupon;

public class ApplyDiscountCouponCommandHandler(BasketService basketService) : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
    {
        var basketAsJson = await basketService.GetBasketFromCache(cancellationToken);

        if (string.IsNullOrEmpty(basketAsJson))
        {
            return ServiceResult<BasketDto>.Error("Basket not found", HttpStatusCode.NotFound);
        }

        var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson)!;

        if (!basket.Items.Any())
        {
            return ServiceResult<BasketDto>.Error("Basket item not found", HttpStatusCode.NotFound);
        }

        basket.ApplyNewDiscount(request.Coupon, request.DiscountRate);
        basketAsJson = JsonSerializer.Serialize(basket);
        await basketService.CreateBasketCacheAsync(basket, cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}
