using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Common;

namespace Web.Api.Features.Categories.GetAllProducts
{
    public class GetAllProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("products/", async ([FromQuery] int pageNumber, [FromQuery] int pageSize, ISender sender) =>
            {
                pageNumber = pageNumber > 0 ? pageNumber : 1;
                pageSize = pageSize > 0 ? pageSize : 10;

                var query = new GetAllProductsQuery(pageNumber, pageSize);
                var result = await sender.Send(query);

                return result.Match(
                    onSuccess: () => Results.Ok(result.Value),
                    onFailure: error => Results.BadRequest(error));

            })
                .WithTags(Tags.Products)
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .MapToApiVersion(1);

        }
    }
}
