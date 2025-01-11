using EFCoreForBeginners.Data;
using EFCoreForBeginners.Models;

using PizzaContext context = new();

var veggieSpecial = new Product()
{
    Name = "Veggie Special",
    Price = 9.99M,
};
context.Products.Add(veggieSpecial);

var deluxeMeat = new Product()
{
    Name = "Deluxe Meat",
    Price = 12.99M,
};
context.Products.Add(deluxeMeat);

context.SaveChanges();

veggieSpecial.Name = "Veggie Special (Updated)";
veggieSpecial.Price = 10.99M;
context.SaveChanges();

var products = context.Products
    .Where(p => p.Price > 10.00M)
    .OrderBy(p => p.Name);

foreach (var product in products)
{
    Console.WriteLine($"Id:    {product.Id}");
    Console.WriteLine($"Name:  {product.Name}");
    Console.WriteLine($"Price: {product.Price}");
    Console.WriteLine(new string('-', 20));
}
