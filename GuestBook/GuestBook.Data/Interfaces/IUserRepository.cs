using System;
using System.Collections.Generic;
using System.Text;

namespace GuestBook.Data.Interfaces
{
    public interface IUserRepository
    {
        Model.User Insert(Model.User guestNote);
        Model.User Update(Model.User guestNote);
        void Delete(int id);
        List<Model.User> List();
        Model.User Get(int id);
    }
}
