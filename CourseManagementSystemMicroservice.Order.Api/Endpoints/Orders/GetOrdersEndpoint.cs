﻿using CourseManagementSystemMicroservice.Order.Application.Features.Orders.GetOrders;
using CourseManagementSystemMicroservice.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementSystemMicroservice.Order.Api.Endpoints.Orders;

public static class GetOrdersEndpoint
{
    public static RouteGroupBuilder GetOrdersGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IMediator mediator) =>
                (await mediator.Send(new GetOrdersQuery())).ToGenericResult())
            .WithName("GetOrders")
            .MapToApiVersion(1, 0)
            .Produces<Guid>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


        return group;
    }
}