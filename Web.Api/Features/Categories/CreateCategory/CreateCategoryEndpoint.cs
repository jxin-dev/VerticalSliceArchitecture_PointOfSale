using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Web.Api.Common;

namespace Web.Api.Features.Categories.CreateCategory
{
    public class CreateCategoryEndpoint : ICarterModule
    {
        public record CreateCategoryRequest(string CategoryName,string Description);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("categories/", async (CreateCategoryRequest request, ISender sender) =>
            {
                var command = new CreateCategoryCommand(request.CategoryName, request.Description);
                var result = await sender.Send(command);

                return result.Match(
                    onSuccess: () => Results.CreatedAtRoute("GetCategory", new { categoryId = result.Value.Id }, result.Value),
                    onFailure: error => Results.BadRequest(error));

            })
                .WithTags(Tags.Categories)
                .WithSummary("Create new category.")
                .MapToApiVersion(1);
        }
    }
}
