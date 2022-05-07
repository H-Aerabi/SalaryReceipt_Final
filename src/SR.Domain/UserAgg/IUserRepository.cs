using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SR.Domain.UserAgg
{
   public  interface IUserRepository
    {
        List<User> GetAll();
        User  GetDetailsBy(int id);   
        void Create(User user);
        bool IsExists(Expression<Func<User,bool>> expression);
        User GetBy(Expression<Func<User,bool>> expression);
        void Save();
    }
}