using Microsoft.AspNetCore.Mvc;
using Shopinger.Domain;
using Shopinger.Domain.Repositories;
using Shopinger.Domain.SearchCriterias;

namespace Shopinger.Api.Controllers;

public class CustomerController : BaseController<Customer>
{
    private readonly ICustomerRepository _customerRepository;
    
    public CustomerController(ICustomerRepository customerRepository) : base(customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    [HttpGet("search")]
    public IActionResult Search(CustomerSearchCriteria criteria)
    {
        return Ok(_customerRepository.Search(criteria));
    }
}