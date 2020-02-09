using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatLogin.Interfaces;

namespace ChatLogin.Services
{
    public class UnitOfWork : Interfaces.IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public DataContext GetDataContext()
        {
            return _dataContext;
        }
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            UserRepository = new UserRepository(_dataContext);
            ChatRepository = new ChatRepository(_dataContext);
        }
        public IUserRepository UserRepository { get; set; }
        public IChatRepository ChatRepository { get; set; }

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
