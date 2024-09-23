using Catalog.Application.Common.Interfaces;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Categories.Commands.AddCategory;

public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, int>
{
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<int> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name)
        {
            Url = request.Image,
            ParentCategory = request.ParentCategory
        };

        _categoryRepository.Add(category);
        await _categoryRepository.SaveChangesAsync();

        return category.Id;
    }
}