using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Pizza.Models;
using Pizza.Data;

namespace EFCoreAspNetApp.Pages.Customers;

public class DetailsModel(PizzaDbContext context) : PageModel
{
    private readonly PizzaDbContext _context = context;

    public Customer Customer { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var customer = await _context.Customers
                .FromSqlInterpolated($"SELECT * FROM Customers WHERE Id = {id}")
                .FirstOrDefaultAsync();

        if (customer is null)
        {
            return NotFound();
        }
        else
        {
            Customer = customer;
        }

        return Page();
    }
}
