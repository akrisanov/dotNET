using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Pizza.Models;
using Pizza.Data;

namespace EFCoreAspNetApp.Pages.Customers;

public class IndexModel(PizzaDbContext context) : PageModel
{
    private readonly PizzaDbContext _context = context;

    public IList<Customer> Customer { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Customer = await _context.Customers.ToListAsync();
    }
}
