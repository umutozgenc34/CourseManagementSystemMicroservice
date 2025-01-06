﻿using CourseManagementSystemMicroservice.Shared.Extensions;
using CourseManagementSystemMicroservice.Shared.Filters;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Create;

public static class CreateCategoryEndpoint
{
    public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) => (await mediator.Send(command)).ToGenericResult())
            .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();
        
        return group;
    }
}
