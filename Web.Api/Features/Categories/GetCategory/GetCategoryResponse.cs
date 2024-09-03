namespace Web.Api.Features.Categories.GetCategory
{
    public record GetCategoryResponse(Guid Id, string CategoryName, string Description);
}
