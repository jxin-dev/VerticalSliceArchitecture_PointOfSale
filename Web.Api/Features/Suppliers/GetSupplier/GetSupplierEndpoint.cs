using Carter;
using MediatR;
using Web.Api.Common;

namespace Web.Api.Features.Suppliers.GetSupplier
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
            app.MapGet("suppliers/{supplierId:guid}", async (Guid supplierId, ISender sender) =>
            {
                var query = new GetSupplierQuery(supplierId);
                var result = await sender.Send(query);

                return result.Match(
                    onSuccess: () => Results.Ok(result.Value),
                    onFailure: error => Results.NotFound(error));

            })
                .WithName("GetSupplier")
                .WithTags(Tags.Suppliers)
                .MapToApiVersion(1);
        }
    }
}
