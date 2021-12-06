
using Recipe_book_api.Context;
using Recipe_book_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipe_book_api.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext context;

        public UserService(DataContext context)
        {
            this.context = context;
        }
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return context.Users.Where(u => u.Id == id).FirstOrDefault();
        }
        public User GetUserByName(string userName)
        {
            return context.Users.Where(u => u.Name == userName).FirstOrDefault();
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0;
        }
    }
}
