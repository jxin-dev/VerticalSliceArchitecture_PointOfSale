using Web.Api.Common;
using Web.Api.Entities.Categories;
using Web.Api.Entities.Suppliers;

namespace Web.Api.Entities.Products
{
    public class Product : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
