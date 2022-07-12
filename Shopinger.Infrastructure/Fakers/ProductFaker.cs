using Bogus;
using Shopinger.Domain;

namespace Shopinger.Infrastructure.Fakers;

public class ProductFaker : Faker<Product>
{
    public ProductFaker()
    {
        StrictMode(true);
        RuleFor(p=>p.Id, f=>f.IndexFaker);
        RuleFor(p=>p.Name, f=>f.Commerce.ProductName());
        RuleFor(p => p.Description, f => f.Lorem.Paragraph());
    }
}