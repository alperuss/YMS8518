using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepository.Services
{
    public class PetRepository:Repository<Models.Pet>,Interfaces.IPetRepository
    {
        private readonly DataContext _dataContext;
        public PetRepository(DataContext dataContext):base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
