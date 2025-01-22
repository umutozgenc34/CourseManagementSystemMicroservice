﻿
using CourseManagementSystemMicroservice.Discount.Api.Repositories;
using CourseManagementSystemMicroservice.Shared.Services;

namespace CourseManagementSystemMicroservice.Discount.Api.Features.Discounts.CreateDiscount;

public class CreateDiscountCommandHandler(BaseDbContext context,IIdentityService identityService) : IRequestHandler<CreateDiscountCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var hasCodeForUser = await context.Discounts.AnyAsync(x => x.UserId.ToString() == request.UserId.ToString() && x.Code == request.Code, cancellationToken: cancellationToken);


        if (hasCodeForUser)
        {
            return ServiceResult.Error("Discount code already exists for this user", HttpStatusCode.BadRequest);
        }

        var discount = new Discount() 
        {
            Id = NewId.NextSequentialGuid(),
            Code = request.Code,
            Created = DateTime.Now,
            Rate = request.Rate,
            Expired = request.Expired,
            UserId = request.UserId
        };

        await context.Discounts.AddAsync(discount, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}
