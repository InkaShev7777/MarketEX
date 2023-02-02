using System;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccessEF.Repositories
{
	public class CategoryRepository : GenericRepository<CategoryProduct>, ICategoryRepository
	{
		public CategoryRepository(DbA92dc1Inkainka7777Context _db) : base(_db)
		{
		}

	}
}

