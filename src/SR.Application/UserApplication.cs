using SR.Application.Contract.common;
using SR.Application.Contract.User;
using SR.Domain.UserAgg;
using SR.Infrastructure.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SR.Application.Security;
using SR.Domain.OrganizationAgg;

using System.Resources;

namespace SR.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;
 
        public UserApplication()
        {
            _userRepository = new UserRepository();
            _organizationRepository=new OrganizationRepository();

        }

        public ResultViewModel<int> Create(CreateUser command)
        {
            //check organization is exist or not
            var organization = _organizationRepository.GetById(command.OrganizationId);
            if (organization == null)
            {
                return new ResultViewModel<int>()
                {
                    IsSuccess = false,
                    Message = "چنین سازمانی یافت نشد"

                };
            }

            //check duplication user 
            if (_userRepository.IsExists(u=>u.NationalCode==command.Code && u.OrganizationId==command.OrganizationId))
            {
                //get the name of code from Resources.User
                string codeName = SR.Application.Contract.Resources.User.UserName;
                return new ResultViewModel<int>()
                {
                    IsSuccess = false,
                    Message = $"کاربری با این  {codeName} از قبل وجود دارد . لطفا با دقت اطلاعات را وارد کنید",
                    Result = 0
                };

            }

            string password = "123456";

            User user = new User(command.Code,command.OrganizationId, password, command.IsAdmin, command.FullName, command.Email, command.PhoneNumber);

            _userRepository.Create(user);
            _userRepository.Save();


            return new ResultViewModel<int>() {

                Message="کاربر با موفقیت اضافه شد ",
                Result=user.Id,
                IsSuccess=true
            };



        }

        public ResultViewModel Edit(FullEditUser command)
        {
           //Get user and cheke if  exists in Databse or not 
            var user = _userRepository.GetDetailsBy(command.Id);

            if (user == null)
            {
               return new  ResultViewModel()
                {
                    IsSuccess=false,
                    Message="کاربری با این مشخصات یافت نشد "
                };
            }

            var userForDuplicate = _userRepository.GetBy(o=>o.NationalCode==command.Code && o.OrganizationId==command.OrganizationId);
            if(userForDuplicate!=null && userForDuplicate.Id!=command.Id)
            {
                string codeName = SR.Application.Contract.Resources.User.UserName;

                return new ResultViewModel()
                {
                    IsSuccess = false,
                    Message = $"کاربری با این  {codeName} از قبل وجود دارد . لطفا با دقت اطلاعات را وارد کنید"
                };
            }
            user.Edit(command.IsAdmin, command.OrganizationId, command.FullName, command.Email, command.PhoneNumber);
            _userRepository.Save();

          

            return new ResultViewModel()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت ویرایش شد "
            }
            ;

        }

        public List<UserViewModel> GetAll()
        {
            return _userRepository.GetAll().Select(u => new UserViewModel()
            {
                UserId=u.Id,
                Code=u.NationalCode,
                FullName=u.FullName,
                IsActive=u.IsActive,
                Organization=u.Organization.Name
                
            }).OrderByDescending(u=>u.UserId).ToList();
        }

        public ResultViewModel<FullEditUser> GetDetails(int id)
        {
            User user = _userRepository.GetDetailsBy(id);
            if (user == null)
            {
                return new ResultViewModel<FullEditUser>()
                {
                    Message = "چنین کاربری یافت نشد",
                    IsSuccess = false

                };
            }

            return new ResultViewModel<FullEditUser>()
            {
                IsSuccess = true,
                Result = new FullEditUser()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    Code=user.NationalCode,
                    OrganizationId=user.OrganizationId,
                    IsAdmin=user.IsAdmin,
                    Organization=user.Organization.Name


                 
                }
            };
        }

        public ResultViewModel<FullEditUser> GetUserBy(string code, int organizationId)
        {
            var user = _userRepository.GetBy(u=>u.NationalCode==code && u.OrganizationId==organizationId);
            if (user == null)
            {
                return new ResultViewModel<FullEditUser>()
                {
                    IsSuccess = false,
                    Message = "جنین کاربری یافت نشد",
                };
            }
            return new ResultViewModel<FullEditUser>()
            {
                IsSuccess=true,
                Result=new FullEditUser()
                {
                    Email=user.Email,
                    FullName=user.FullName,
                    Id=user.Id,
                    IsAdmin=user.IsAdmin,
                    Code=user.NationalCode,
                    OrganizationId=user.OrganizationId,
                    PhoneNumber=user.PhoneNumber
                    
                }
            };
        }

        public ResultViewModel<FullEditUser> LoginUser(LoginUser command)
        {
            var user = _userRepository.GetBy(u=>u.NationalCode==command.Code && u.OrganizationId==command.OrganizationId);


            if (user!=null && user.Password == command.Password)
            {
                return new ResultViewModel<FullEditUser>()
                {
                    IsSuccess = true,
                    Message = "لاگین با موفقیت انجام شد",
                    Result = new FullEditUser()
                    {
                        Email = user.Email,
                        FullName = user.FullName,
                        Id = user.Id,
                        Code = user.NationalCode,
                        PhoneNumber = user.PhoneNumber,
                        OrganizationId = user.OrganizationId,
                        IsAdmin = user.IsAdmin
                       
                    }
                };
            }
            return new ResultViewModel<FullEditUser>()
            {
                IsSuccess = false,
                Message = "کاربری با چنین مشخصات یافت نشد"
            };
        }
    }
}
