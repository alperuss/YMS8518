using Login.Interfaces;
using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Services
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {        

        public EntryRepository(DataContext dataContext) : base(dataContext)
        {
            
        }

    }
}
