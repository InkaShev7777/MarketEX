using System;
using Domain.Models;

namespace Domain.Interfaces
{
	public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetByCategoryID(int id);
        List<Product> SearchProduct(string text);
    }
}

