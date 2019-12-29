using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepository.Services
{
    public class BookRepository:Repository<Models.Book>,Interfaces.IBookRepositorycs
    {
        private readonly DataContext _dataContext;
        public BookRepository(DataContext dataContext):base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
