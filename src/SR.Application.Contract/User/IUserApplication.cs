using SR.Application.Contract.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Application.Contract.User
{
    public interface IUserApplication
    {
        List<UserViewModel> GetAll();
        ResultViewModel<int> Create(CreateUser command);
        ResultViewModel Edit(FullEditUser comman);
        ResultViewModel<FullEditUser> GetDetails(int id);
        ResultViewModel<FullEditUser> GetUserBy(string code, int organizationId);
      ResultViewModel<FullEditUser> LoginUser(LoginUser command );

    }

   
}
