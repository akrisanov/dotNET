namespace Pizza.Models;

public partial class Customer
{
    public string FullName
    {
        get => $"{FirstName} {LastName}";
    }
}
