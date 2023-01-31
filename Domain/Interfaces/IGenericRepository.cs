using System;
namespace Domain.Interfaces
{
	public interface IGenericRepository<T> where T:class
	{
		IEnumerable<T> GetAll();
	}
}

