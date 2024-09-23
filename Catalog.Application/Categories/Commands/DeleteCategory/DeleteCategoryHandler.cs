using Catalog.Application.Common.Interfaces;
using MediatR;

namespace Catalog.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<DeleteCategoryRequest, bool>
{
    public async Task<bool> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.Id);

        if (category == null)
        {
            return false;
        }

        categoryRepository.Delete(category);
        await categoryRepository.SaveChangesAsync();

        return true;
    }
}