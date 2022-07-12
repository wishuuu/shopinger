using Bogus;
using Microsoft.Extensions.Options;
using Shopinger.Domain;
using Shopinger.Domain.Repositories;
using Shopinger.Domain.SearchCriterias;
using Shopinger.Infrastructure.Fakers;

namespace Shopinger.Infrastructure;

public class FakeEmployeeRepository : FakeEntityRepository<Employee>, IEmployeeRepository
{
    public FakeEmployeeRepository(Faker<Employee> faker, IOptions<FakeRepositoryOptions> options) : base(faker, options)
    {
    }

    private IEnumerable<Employee> Search(EmployeeSearchCriteria criteria)
    {   
        var employees = Entities.AsQueryable();

        if (!string.IsNullOrEmpty(criteria.FirstName))
        {
            employees = employees.Where(e => e.FirstName.Contains(criteria.FirstName));
        }
        
        if (!string.IsNullOrEmpty(criteria.LastName))
        {
            employees = employees.Where(e => e.LastName.Contains(criteria.LastName));
        }
        
        if (!string.IsNullOrEmpty(criteria.Email))
        {
            employees = employees.Where(e => e.Email.Contains(criteria.Email));
        }

        return employees.AsEnumerable();
    }

    public override IEnumerable<Employee> Search(SearchCriteria<Employee> criteria)
    {
        return Search(criteria as EmployeeSearchCriteria);
    }
}