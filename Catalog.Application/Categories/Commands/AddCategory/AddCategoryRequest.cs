using MediatR;

namespace Catalog.Application.Categories.Commands.AddCategory;

public record AddCategoryRequest(string Name, string Image, string ParentCategory) : IRequest<int>;