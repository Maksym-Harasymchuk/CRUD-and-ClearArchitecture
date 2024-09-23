using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Interfaces;

public interface IItemRepository : IRepository<Item, int> 
{
}