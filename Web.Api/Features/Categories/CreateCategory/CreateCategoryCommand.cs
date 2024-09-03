using MediatR;
using Web.Api.Common;

namespace Web.Api.Features.Categories.CreateCategory
{
   public record CreateCategoryCommand(
       string CategoryName, 
       string Description) : IRequest<Result<CreateCategoryResponse>>;
}
