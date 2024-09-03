using MediatR;
using Web.Api.Domain.Products.DomainEvents;

namespace Web.Api.Features.Products.CreateProduct
{
    public class ProductCreatedEvent : INotificationHandler<ProductCreatedDomainEvent>
    {
        public Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

       
    }
}
