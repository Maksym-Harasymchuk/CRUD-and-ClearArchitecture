using MediatR;

namespace Catalog.Application.Categories.Queries;

public class CategoryQuery : IRequest<List<Domain.Entities.Category>>
{
}