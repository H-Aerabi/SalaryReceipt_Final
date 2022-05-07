using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Application.Contract.common;

namespace SR.Application.Contract.Organization
{
    public interface IOrganizationApplication
    {
        List<OrganizationViewModel> GetAll();
       ResultViewModel<int>  Create(CreateOrganization command);
       ResultViewModel<EditOrganization> GetDetails(int id);
        ResultViewModel Edit(EditOrganization command);
        ResultViewModel Remove(int id);
    }
}
