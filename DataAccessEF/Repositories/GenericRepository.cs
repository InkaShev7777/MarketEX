using System;
using Domain.Interfaces;

namespace DataAccessEF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbA92dc1Inkainka7777Context db;
        public GenericRepository(DbA92dc1Inkainka7777Context _db)
        {
            this.db = _db;
        }

        public void Add(T item)
        {
            this.db.Set<T>().Add(item);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            T item = this.db.Set<T>().Find(id);
            if(item != null)
            {
                this.db.Set<T>().Remove(item);
                this.db.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return this.db.Set<T>().ToList();
        }

        public void Update(T item)
        {
                this.db.Set<T>().Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.db.SaveChanges();
        }

        //public IEnumerable<T> GetByCategoryID(int id)
        //{
        //    return this.db.Products.Where(x => x.IdCategory == id).ToList();
        //}
    }
}

