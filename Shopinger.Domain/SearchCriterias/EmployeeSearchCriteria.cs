﻿namespace Shopinger.Domain.SearchCriterias;

public class EmployeeSearchCriteria : SearchCriteria
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}