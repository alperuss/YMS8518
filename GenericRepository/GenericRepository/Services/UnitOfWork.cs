using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRepository.Interfaces;

namespace GenericRepository.Services
{
    public class UnitOfWork : Interfaces.IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public UnitOfWork(DataContext datacontext)
        {
            _dataContext = datacontext;
            UserRepository = new Services.UserRepository(_dataContext) ;
            PetRepository = new Services.PetRepository(_dataContext);
            BookRepositorycs = new Services.BookRepository(_dataContext);
        }
        public IUserRepository UserRepository { get; set; }
        public IPetRepository PetRepository { get; set; }
        public IBookRepositorycs BookRepositorycs { get; set; }

        public int Complete()
        {
            return _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
