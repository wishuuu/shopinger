using Bogus;
using Microsoft.Extensions.Options;
using Shopinger.Domain;
using Shopinger.Domain.Repositories;
using Shopinger.Infrastructure.Fakers;

namespace Shopinger.Infrastructure;

public class FakeProductRepository: FakeEntityRepository<Product>, IProductRepository
{
    public FakeProductRepository(Faker<Product> faker, IOptions<FakeRepositoryOptions> options) : base(faker, options)
    {
    }
}