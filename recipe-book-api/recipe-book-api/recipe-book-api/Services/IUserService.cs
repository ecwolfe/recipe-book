using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe_book_api.Entities;


namespace Recipe_book_api.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        User GetUserByName(string userName);
        void AddUser(User user);  
        bool Save();
    }
} 
