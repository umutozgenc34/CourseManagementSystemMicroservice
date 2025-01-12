﻿using CourseManagementSystemMicroservice.Shared.Extensions;
using MediatR;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.GetBasket;

public static class GetBasketEndpoint
{
    public static RouteGroupBuilder GetBasketGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/user",
                async (IMediator mediator) =>
                    (await mediator.Send(new GetBasketQuery())).ToGenericResult())
            .WithName("GetBasket")
            .MapToApiVersion(1, 0);


        return group;
    }
}
