﻿using FluentValidation;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.ApplyDiscountCoupon;

public class ApplyDiscountCouponCommandValidator : AbstractValidator<ApplyDiscountCouponCommand>
{
    public ApplyDiscountCouponCommandValidator()
    {
        RuleFor(x => x.Coupon).NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.DiscountRate).GreaterThan(0).WithMessage("{PropertyName} must be greater than zero");
    }
}