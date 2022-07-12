namespace Shopinger.Domain.SearchCriterias;

public class CustomerSearchCriteria : SearchCriteria<Customer>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}