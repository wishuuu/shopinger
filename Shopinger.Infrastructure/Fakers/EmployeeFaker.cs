using Bogus;
using Shopinger.Domain;

namespace Shopinger.Infrastructure.Fakers;

public class EmployeeFaker : Faker<Employee>
{
    public EmployeeFaker()
    {
        StrictMode(true);
        RuleFor(p=>p.Id, f=>f.IndexFaker);
        RuleFor(p=>p.FirstName, f=>f.Name.FirstName());
        RuleFor(p=>p.LastName, f=>f.Name.LastName());
        RuleFor(p=>p.Email, f=>f.Internet.Email());
        RuleFor(p=>p.Login, f=>f.Internet.UserName());
        RuleFor(p=>p.Password, f=>f.Internet.Password());
    }
}