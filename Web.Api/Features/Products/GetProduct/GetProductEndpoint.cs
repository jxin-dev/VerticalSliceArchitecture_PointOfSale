using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Common;

namespace Web.Api.Features.Products.GetProduct
{
    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("products/{productId:guid}", async (Guid productId, ISender sender) =>
            {
                var query = new GetProductQuery(productId);
                var result = await sender.Send(query);

                return result.Match(
                    onSuccess: () => Results.Ok(result.Value),
                    onFailure: error => Results.BadRequest(error));

            })
                .WithName("GetProduct")
                .WithTags(Tags.Products)
                .MapToApiVersion(1);
        }
    }
}
