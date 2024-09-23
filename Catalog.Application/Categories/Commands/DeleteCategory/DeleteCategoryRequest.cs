using MediatR;

namespace Catalog.Application.Categories.Commands.DeleteCategory;

public record DeleteCategoryRequest(int Id) : IRequest<bool>;