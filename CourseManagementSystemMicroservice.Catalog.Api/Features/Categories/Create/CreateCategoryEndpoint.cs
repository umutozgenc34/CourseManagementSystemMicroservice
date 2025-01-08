﻿using Asp.Versioning.Builder;
using CourseManagementSystemMicroservice.Shared.Extensions;
using CourseManagementSystemMicroservice.Shared.Filters;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Create;

public static class CreateCategoryEndpoint
{
    public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) => (await mediator.Send(command)).ToGenericResult())
            .WithName("CreateCategory")
            .MapToApiVersion(1,0)
            .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();
        
        return group;
    }
}
