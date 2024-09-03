using MediatR;
using Web.Api.Common;

namespace Web.Api.Domain.Products.DomainEvents
{
    public record ProductCreatedDomainEvent(Guid productId) : IDomainEvent;

}
