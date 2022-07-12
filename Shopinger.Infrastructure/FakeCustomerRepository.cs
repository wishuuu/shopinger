using Bogus;
using Microsoft.Extensions.Options;
using Shopinger.Domain;
using Shopinger.Domain.Repositories;
using Shopinger.Infrastructure.Fakers;

namespace Shopinger.Infrastructure;

public class FakeCustomerRepository : FakeEntityRepository<Customer>, ICustomerRepository
{
    public FakeCustomerRepository(Faker<Customer> faker, IOptions<FakeRepositoryOptions> options) : base(faker, options)
    {
    }
}