using SR.Domain.OrganizationAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Infrastructure.EF.Contexts;
using System.Linq.Expressions;

namespace SR.Infrastructure.EF.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly SalaryReceiptContext _context;
        public OrganizationRepository()
        {
            _context = new SalaryReceiptContext();
        }
        public void Create(Organization organization)
        {
            _context.Organizations.Add(organization);
            
        }

        public List<Organization> GetAll()
        {
            return _context.Organizations.ToList();
        }

        public Organization GetById(int id)
        {
            return _context.Organizations.Find(id);
        }

        public bool IsAnyUserInOrganization(int organizationId)
        {
            return _context.Users.Any(u => u.OrganizationId == organizationId);
        }

        public bool IsExists(Expression<Func<Organization, bool>> expression)
        {
            return _context.Organizations.Any(expression);
        }

        public void Remove(Organization organization)
        {
            _context.Organizations.Remove(organization);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
