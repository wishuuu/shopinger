using Microsoft.AspNetCore.Mvc;
using Shopinger.Domain;
using Shopinger.Domain.Repositories;
using Shopinger.Domain.SearchCriterias;

namespace Shopinger.Api.Controllers;

public class EmployeeController : BaseController<Employee>
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public EmployeeController(IEmployeeRepository employeeRepository) : base(employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(EmployeeSearchCriteria criteria)
    {
        var employees = _employeeRepository.Search(criteria);
        return Ok(employees);
    }
}