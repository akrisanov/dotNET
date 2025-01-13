using Pizza.Data;
using Pizza.Models;

using PizzaContext context = new();

var me = new Customer
{
    FirstName = "Andrey",
    LastName = "Krisanov"
};
context.Customers.Add(me);
context.SaveChanges();

foreach (var c in context.Customers)
{
    Console.WriteLine(c.FullName);
}
