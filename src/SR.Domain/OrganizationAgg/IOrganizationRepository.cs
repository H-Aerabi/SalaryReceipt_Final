using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SR.Domain.OrganizationAgg
{
    public interface IOrganizationRepository
    {
        List<Organization> GetAll();
        Organization GetById(int id);
        void Create(Organization organization);
        bool IsExists(Expression<Func<Organization, bool>> expression);
        void Remove(Organization organization);
        bool IsAnyUserInOrganization(int organizationId);
        void Save();

    }
}
