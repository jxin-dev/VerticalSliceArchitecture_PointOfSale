using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Common;

namespace Web.Api.Features.Categories.GetCategory
{
    public class GetCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("categories/{categoryId:guid}", async (Guid categoryId, ISender sender) =>
            {
                var query = new GetCategoryQuery(categoryId);
                var result = await sender.Send(query);

                return result.Match(
                    onSuccess: () => Results.Ok(result.Value),
                    onFailure: error => Results.NotFound(error));

            })
                .WithName("GetCategory")
                .WithTags(Tags.Categories)
                .MapToApiVersion(1);
        }
    }
}
