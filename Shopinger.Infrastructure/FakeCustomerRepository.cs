using Bogus;
using Microsoft.Extensions.Options;
using Shopinger.Domain;
using Shopinger.Domain.Repositories;
using Shopinger.Domain.SearchCriterias;
using Shopinger.Infrastructure.Fakers;

namespace Shopinger.Infrastructure;

public class FakeCustomerRepository : FakeEntityRepository<Customer>, ICustomerRepository
{
    public FakeCustomerRepository(Faker<Customer> faker, IOptions<FakeRepositoryOptions> options) : base(faker, options)
    {
    }

    private IEnumerable<Customer> Search(CustomerSearchCriteria criteria)
    {
        var customers = Entities.AsQueryable();
        
        if (!string.IsNullOrEmpty(criteria.FirstName))
        {
            customers = customers.Where(c => c.FirstName.Contains(criteria.FirstName));
        }
        
        if (!string.IsNullOrEmpty(criteria.LastName))
        {
            customers = customers.Where(c => c.LastName.Contains(criteria.LastName));
        }
        
        if (!string.IsNullOrEmpty(criteria.Email))
        {
            customers = customers.Where(c => c.Email.Contains(criteria.Email));
        }

        return customers.AsEnumerable();
    }

    public override IEnumerable<Customer> Search(SearchCriteria<Customer> criteria)
    {
        return Search(criteria as CustomerSearchCriteria);
    }
}