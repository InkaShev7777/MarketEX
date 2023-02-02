using System;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccessEF.Repositories
{
	public class ProductRepository :GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(DbA92dc1Inkainka7777Context _db):base(_db)
		{
		}

        public List<Product> GetByCategoryID(int id)
        {
            return this.db.Products.Where(x => x.IdCategory == id).ToList();
        }

        public List<Product> SearchProduct(string text)
        {
            return this.db.Products.Where(x => x.Title.ToLower().Contains(text.ToLower())).ToList();
        }
    }
}

