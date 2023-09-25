﻿using HotelManagementApi.Contexts;
using HotelManagementApi.Interfaces;
using HotelManagementApi.Models;

namespace HotelManagementApi.Repositories
{
    public class UserRepository : IRepository<string, User>
    {
        private readonly HotelContext _context;

        public UserRepository(HotelContext context)
        {
            _context = context;
        }


        public User Add(User item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }



        public User Delete(string key)
        {
            var user = Get(key);
            if (user != null)
            {
                _context.users.Remove(user);
                _context.SaveChanges();
                return user;
            }
            return null;



        }



        public User Get(string key)
        {
            var user = _context.users.FirstOrDefault(us => us.UserName == key);
            return user;
        }



        public List<User> GetAll()
        {
            return _context.users.ToList();
        }



        public User Update(User item)
        {
            _context.Entry<User>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
