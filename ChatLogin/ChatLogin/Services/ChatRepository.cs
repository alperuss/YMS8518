using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatLogin.Services
{
    public class ChatRepository:Repository<Models.Chat>,Interfaces.IChatRepository
    {
        public ChatRepository(DataContext dataContext) : base(dataContext) 
        {

        }
    }
}
