using MediatR;
using Web.Api.Common;

namespace Web.Api.Features.Categories.GetCategory
{
    public record GetCategoryQuery(Guid Id) : IRequest<Result<GetCategoryResponse>>;
}
