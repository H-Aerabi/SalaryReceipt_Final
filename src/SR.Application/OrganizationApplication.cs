using SR.Application.Contract.common;
using SR.Application.Contract.Organization;
using SR.Domain.OrganizationAgg;
using SR.Infrastructure.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Application
{
    public class OrganizationApplication : IOrganizationApplication
    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationApplication()
        {
            _organizationRepository = new OrganizationRepository();
        }
        public ResultViewModel<int> Create(CreateOrganization command)
        {
            if (_organizationRepository.IsExists(o => o.Code == command.Code))
            {
                return new ResultViewModel<int>()
                {
                    IsSuccess = false,
                    Message = "سازمانی با این کد قبلا ایجاد شده است ، لطفا کد غیر تکراری وارد کنید"
                };
            }
            if (_organizationRepository.IsExists(o => o.Name == command.Name))
            {
                return new ResultViewModel<int>()
                {
                    IsSuccess = false,
                    Message = "سازمانی با این نام قبلا ایجاد شده است ، لطفا نام غیر تکراری وارد کنید"
                };
            }

            var organization = new Organization(command.Name, command.Code, command.Address, command.PhoneNumber, command.Website);
            _organizationRepository.Create(organization);
            _organizationRepository.Save();

            return new ResultViewModel<int>()
            {

                IsSuccess = true,
                Result = organization.Id,
                Message = "سازمان با موفقیت ایجاد شد "
            };


        }

        public ResultViewModel Edit(EditOrganization command)
        {
            var organization = _organizationRepository.GetById(command.Id);
            if (organization == null)
            {
                return new ResultViewModel()
                {
                    IsSuccess = false,
                    Message = "سازمانی یافت نشد"
                };
            }
            if (_organizationRepository.IsExists(o => o.Code == command.Code && o.Id != command.Id))
            {
                return new ResultViewModel()
                {
                    IsSuccess = false,
                    Message = "سازمانی با این کد قبلا ایجاد شده است ، کد دیگری را وارد کنید"
                };

            }
            if (_organizationRepository.IsExists(o => o.Name == command.Name && o.Id != command.Id))
            {
                return new ResultViewModel()
                {
                    IsSuccess = false,
                    Message = "سازمانی با این نام قبلا ایجاد شده است ، لطفا نام دیگری وارد کنید"
                };
            }

            organization.Edit(command.Code, command.Name, command.Address, command.PhoneNumber, command.Website);
            _organizationRepository.Save();
            return new ResultViewModel()
            {
                IsSuccess = true,
                Message = "عملیات موفق"
            };
        }

        public List<OrganizationViewModel> GetAll()
        {
            return _organizationRepository.GetAll().Select(o => new OrganizationViewModel()
            {
                Name = o.Name,
                PhoneNumber = o.PhoneNumber,
                Code = o.Code,
                Id = o.Id

            }).OrderByDescending(o => o.Id).ToList();
        }

        public ResultViewModel<EditOrganization> GetDetails(int id)
        {
            var organization = _organizationRepository.GetById(id);
            if (organization == null)
            {
                return new ResultViewModel<EditOrganization>()
                {
                    IsSuccess = false,
                    Message = "سازمانی با این مشخصات یافت نشد"
                };
            }

            return new ResultViewModel<EditOrganization>()
            {
                IsSuccess = true,
                Result = new EditOrganization()
                {
                    Address = organization.Address,
                    Code = organization.Code,
                    Id = organization.Id,
                    Name = organization.Name,
                    PhoneNumber = organization.PhoneNumber,
                    Website = organization.Website
                }
            };
        }

        public ResultViewModel Remove(int id)
        {
            var organization = _organizationRepository.GetById(id);
            if (organization == null)
            {
                return new ResultViewModel()
                {
                    IsSuccess = false,
                    Message = "سازمانی با این شناسه برای حذف پیدا نشد"
                };


            }
            if (_organizationRepository.IsAnyUserInOrganization(id))
            {
                return new ResultViewModel()
                {
                    IsSuccess = false,
                    Message = "سازمان را نمی توان حذف کرد ،زیرا افرادی برای این سازمان ثبت شده است . می توانید ابتدا اقدام به حذف کاربران این سازمان کرده و سپس اقدام کنید "


                };

              }
            _organizationRepository.Remove(organization);

            _organizationRepository.Save();

            return new ResultViewModel()
            {
                IsSuccess = true,
                Message = "حذف با موفقیت انجام شد"
            };

        }
    }
}

