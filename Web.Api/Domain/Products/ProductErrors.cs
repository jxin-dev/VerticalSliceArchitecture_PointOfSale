using Web.Api.Common;

namespace Web.Api.Entities.Products
{
    public static class ProductErrors
    {
        public static Error NotFound()
        {
            return new Error("Product.NotFound", "The requested resource could not be found.");
        }
        public static Error NotFound(Guid productId)
        {
            return new Error("Product.NotFound", $"The product with Id = {productId} was not found.");
        }
    }
}
