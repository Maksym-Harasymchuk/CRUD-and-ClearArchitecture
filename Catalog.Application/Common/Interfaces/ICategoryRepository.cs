﻿using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Interfaces;

public interface ICategoryRepository : IRepository<Category, int>
{
    Task<List<Category>> GetCategoriesAsync();
}