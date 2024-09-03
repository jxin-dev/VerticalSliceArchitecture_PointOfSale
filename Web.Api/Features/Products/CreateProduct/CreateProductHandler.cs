using MediatR;
using Web.Api.Common;
using Web.Api.Domain.Products.DomainEvents;
using Web.Api.Entities.Categories;
using Web.Api.Entities.Products;
using Web.Api.Entities.Suppliers;

namespace Web.Api.Features.Products.CreateProduct
{
    public partial class CreateProductHandler(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        ISupplierRepository supplierRepository) : IRequestHandler<CreateProductCommand, Result<CreateProductResponse>>
    {
        public async Task<Result<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetCategoryAsync(category => category.Id == request.CategoryId);

            if (category is null)
            {
                return Result.Failure<CreateProductResponse>(CategoryErrors.NotFound(request.CategoryId), ErrorType.NotFound);
            }

            var supplier = await supplierRepository.GetSupplierAsync(supplier => supplier.Id == request.SupplierId);
           
            if (supplier is null)
            {
                return Result.Failure<CreateProductResponse>(SupplierErrors.NotFound(request.SupplierId), ErrorType.NotFound);
            }


            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CategoryId = request.CategoryId,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                SupplierId = request.SupplierId
            };

            product.Raise(new ProductCreatedDomainEvent(product.Id));

            await productRepository.AddProductAsync(product);

            return Result.Success(new CreateProductResponse(product.Id));

        }
    }
}
