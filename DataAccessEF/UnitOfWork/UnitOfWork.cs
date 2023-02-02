using System;
using DataAccessEF.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.UnitOfWork;

namespace DataAccessEF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbA92dc1Inkainka7777Context context;

        public ICategoryRepository categoryRepository { get; private set; }

        public IProductRepository productRepository { get; private set; }

        public UnitOfWork(DbA92dc1Inkainka7777Context _context)
        {
            this.context = _context;
            this.categoryRepository = new CategoryRepository(this.context);
            this.productRepository = new ProductRepository(this.context);
        }


        public int Complete() => this.context.SaveChanges();

        public void Dispose() => this.context.Dispose();
    }
}

