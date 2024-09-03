using Carter;
using MediatR;
using Web.Api.Common;

namespace Web.Api.Features.Products.CreateProduct
{
    public class CreateProductEndpoint : ICarterModule
    {
        public record CreateProductRequest(
            string Name,
            Guid CategoryId,
            decimal Price,
            int StockQuantity,
            Guid SupplierId);


        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("products/", async (CreateProductRequest request, ISender sender) =>
            {
                var command = new CreateProductCommand(
                    request.Name,
                    request.CategoryId,
                    request.Price,
                    request.StockQuantity,
                    request.SupplierId);

                var result = await sender.Send(command);

                return result.Match(
                    onSuccess: () => Results.CreatedAtRoute("GetProduct", new { productId = result.Value.Id }, result.Value),
                    onFailure: error =>
                    {
                        return result.ErrorType switch
                        {
                            ErrorType.NotFound => Results.NotFound(error),
                            _ => Results.StatusCode(500)
                        };
                    });


            })
                .WithTags(Tags.Products)
                .WithSummary("Create new product.")
                .MapToApiVersion(1);

            app.MapPost("products/", async (CreateProductRequest request, ISender sender) =>
            {
                var command = new CreateProductCommand(
                    request.Name,
                    request.CategoryId,
                    request.Price,
                    request.StockQuantity,
                    request.SupplierId);

                var result = await sender.Send(command);

                return result.Match(
                    onSuccess: () => Results.CreatedAtRoute("GetProduct", new { productId = result.Value.Id }, result.Value),
                    onFailure: error =>
                    {
                        return result.ErrorType switch
                        {
                            ErrorType.NotFound => Results.NotFound(error),
                            _ => Results.StatusCode(500)
                        };
                    });


            })
               .WithTags(Tags.Products)
               .WithSummary("Create new product.")
               .MapToApiVersion(2);
        }
    }
}
