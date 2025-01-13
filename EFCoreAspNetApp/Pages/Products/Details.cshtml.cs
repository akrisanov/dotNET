using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Pizza.Data;
using Pizza.Models;

namespace EFCoreAspNetApp.Pages.Products;

public class DetailsModel(PizzaDbContext context) : PageModel
{
    private readonly PizzaDbContext _context = context;

    public Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        // var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
        // FirstAsync() checks the snapshot first before querying the database
        var product = await _context.Products.FirstAsync(m => m.Id == id);

        if (product is null)
        {
            return NotFound();
        }
        else
        {
            Product = product;
        }

        return Page();
    }
}
