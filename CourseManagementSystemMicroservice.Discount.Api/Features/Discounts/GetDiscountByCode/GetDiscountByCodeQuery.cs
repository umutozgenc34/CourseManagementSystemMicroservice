﻿namespace CourseManagementSystemMicroservice.Discount.Api.Features.Discounts.GetDiscountByCode;

public record GetDiscountByCodeQuery(string Code) : IRequestByServiceResult<GetDiscountByCodeQueryResponse>;

