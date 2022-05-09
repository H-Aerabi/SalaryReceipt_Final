using SR.Domain.UserAgg;
using SR.Infrastructure.EF.Contexts;
using SR.Shared.Dto_ViewModel;
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

        public List<UserViewModel> Search(SearchModel searchModel)
        {

            var users = _context.Users.Include("Organization").Select(u=>new UserViewModel()
            {
                Code=u.Code,
                FullName=u.FullName,
                IsActive=u.IsActive,
                Organization=u.Organization.Name,
                UserId=u.Id
            }).AsQueryable();
            //filter by Code
            if (!string.IsNullOrWhiteSpace(searchModel.Code))
            {
                users = users.Where(u => u.Code.Contains(searchModel.Code));
            }
            //filter by FullName
            if (!string.IsNullOrWhiteSpace(searchModel.FullName))
            {
                users = users.Where(u => u.FullName.Contains(searchModel.FullName));
            }
           
            return users.ToList();
        }
    }
}
