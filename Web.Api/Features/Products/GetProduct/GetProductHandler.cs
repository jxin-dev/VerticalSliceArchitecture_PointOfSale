using MediatR;
using Web.Api.Common;
using Web.Api.Entities.Categories;
using Web.Api.Entities.Products;
using Web.Api.Entities.Suppliers;

namespace Web.Api.Features.Products.GetProduct
{
    public class GetProductHandler(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        ISupplierRepository supplierRepository) : IRequestHandler<GetProductQuery, Result<GetProductResponse>>
    {
        public async Task<Result<GetProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductAsync(product => product.Id == request.Id);
            if (product is null)
            {
                return Result.Failure<GetProductResponse>(ProductErrors.NotFound(request.Id), ErrorType.NotFound);
            }

            //var category = await categoryRepository.GetCategoryAsync(category => category.Id == product.CategoryId);

            //var supplier = await supplierRepository.GetSupplierAsync(supplier => supplier.Id == product.SupplierId);

            //return Result.Success(new GetProductResponse(
            //    product.Id,
            //    product.Name,
            //    new CategoryResponse(
            //        category.Id,
            //        category.CategoryName,
            //        category.Description),
            //    product.Price,
            //    product.StockQuantity,
            //    new SupplierResponse(
            //        supplier.Id,
            //        supplier.SupplierName,
            //        supplier.ContactName,
            //        supplier.Phone,
            //        supplier.Address)));

            return Result.Success(new GetProductResponse(
                product.Id,
                product.Name,
                new CategoryResponse(
                    product.Category.Id,
                    product.Category.CategoryName,
                    product.Category.Description),
                product.Price,
                product.StockQuantity,
                new SupplierResponse(
                    product.Supplier.Id,
                    product.Supplier.SupplierName,
                    product.Supplier.ContactName,
                    product.Supplier.Phone,
                    product.Supplier.Address)));
        }
    }
}
