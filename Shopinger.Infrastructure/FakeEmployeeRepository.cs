using Bogus;
using Microsoft.Extensions.Options;
using Shopinger.Domain;
using Shopinger.Domain.Repositories;
using Shopinger.Infrastructure.Fakers;

namespace Shopinger.Infrastructure;

public class FakeEmployeeRepository : FakeEntityRepository<Employee>, IEmployeeRepository
{
    public FakeEmployeeRepository(Faker<Employee> faker, IOptions<FakeRepositoryOptions> options) : base(faker, options)
    {
    }
}