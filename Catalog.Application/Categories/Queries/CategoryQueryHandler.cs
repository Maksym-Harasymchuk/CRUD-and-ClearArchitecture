using Catalog.Application.Common.Interfaces;
using MediatR;

namespace Catalog.Application.Categories.Queries;

public class CategoryQueryHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<CategoryQuery, List<Domain.Entities.Category>>
{
    public Task<List<Domain.Entities.Category>> Handle(CategoryQuery request, CancellationToken cancellationToken)
    {
        return categoryRepository.GetCategoriesAsync();
    }
}