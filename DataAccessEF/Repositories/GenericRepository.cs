using System;
using Domain.Interfaces;

namespace DataAccessEF.Repositories
{
	public class GenericRepository<T>:IGenericRepository<T> where T:class
	{
        protected readonly DbA92dc1Inkainka7777Context db;
		public GenericRepository(DbA92dc1Inkainka7777Context _db)
		{
            this.db = _db;
		}

        public IEnumerable<T> GetAll()
        {
            return this.db.Set<T>().ToList();
        }
    }
}

