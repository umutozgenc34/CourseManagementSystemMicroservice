﻿using Asp.Versioning.Builder;

namespace CourseManagementSystemMicroservice.Order.Api.Endpoints.Orders;

public static class OrderEndpointExt
{
    public static void AddOrderGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/orders").WithTags("Orders")
            .WithApiVersionSet(apiVersionSet)
            .CreateOrderGroupItemEndpoint();
    }
}