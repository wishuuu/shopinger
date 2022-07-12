namespace Shopinger.Domain;

public class Customer : BaseClassEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    public string Login { get; set; }
    public string Password { get; set; }
    

    public void CopyProperties(Customer customer)
    {
        FirstName = customer.FirstName;
        LastName = customer.LastName;
        Email = customer.Email;
        Login = customer.Login;
        Password = customer.Password;
    }
}