using Carter;
using MediatR;
using Web.Api.Common;

namespace Web.Api.Features.Suppliers.CreateSupplier
{
    public class GetSupplierEndpoint : ICarterModule
    {
        public record CreateSupplierRequest(
            string SupplierName,
            string ContactName,
            string Phone,
            string Address);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("suppliers/", async (CreateSupplierRequest request, ISender sender) =>
            {
                var command = new GetSupplierQuery(
                    request.SupplierName,
                    request.ContactName,
                    request.Phone,
                    request.Address);

                var result = await sender.Send(command);

                return result.Match(
                    onSuccess: () => Results.CreatedAtRoute("GetSupplier", new { supplierId = result.Value.Id }, result.Value),
                    onFailure: error => Results.BadRequest(error));

            })
                .WithTags(Tags.Suppliers)
                .MapToApiVersion(1);

        }
    }
}
