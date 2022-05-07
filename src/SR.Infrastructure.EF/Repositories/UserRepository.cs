using SR.Domain.UserAgg;
using SR.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SR.Infrastructure.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SalaryReceiptContext _context;

        public UserRepository()
        {
            _context = new SalaryReceiptContext();
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
           
            
        }

        public List<User> GetAll()
        {
            return _context.Users.Include("Organization").ToList();
        }

        public User GetBy(Expression<Func<User, bool>> expression)
        {
            return _context.Users.Where(expression).SingleOrDefault();
        }

        public User GetDetailsBy(int id)
        {
            return _context.Users.Include("Organization").Where(u => u.Id == id).SingleOrDefault();
        }

   

        public bool IsExists(Expression<Func<User,bool>> expression)
        {
            return _context.Users.Any(expression);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

       
    }
}
