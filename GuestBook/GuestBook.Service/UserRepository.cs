using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuestBook.Data.Model;

namespace GuestBook.Service
{
    public class UserRepository:Data.Interfaces.IUserRepository
    {
        private readonly Data.Context.DataContext _dataContext;
        

        public void Delete(int id)
        {
            Data.Model.User guestNote = Get(id);
            _dataContext.Users.Remove(guestNote);
            _dataContext.SaveChanges();
        }

        public User Get(int id)
        {
            return _dataContext.Users.Find(id);
        }

        public User Insert(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();

            return user;
        }

        public List<User> List()
        {
            return _dataContext.Users.ToList(); 

        }

        public User Update(User user)
        {
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();

            return user;
        }
    }
}
