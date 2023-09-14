using UserProductAPI.Contexts;
using UserProductAPI.Interfaces;
using UserProductAPI.Models;



namespace UserProductAPI.Repositories
{
    public class UserRepository : IRepository<string, User>
    {
        private readonly UserProductContext _context;



        public UserRepository(UserProductContext context)
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
            var user = _context.users.FirstOrDefault(us => us.Username == key);
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