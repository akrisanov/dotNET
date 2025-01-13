using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pizza.Data;
using Pizza.Models;

namespace EFCoreAspNetApp.Pages.Products;

public class IndexModel(PizzaDbContext context) : PageModel
{
    private readonly PizzaDbContext _context = context;

    public IList<Product> Product { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Product = await _context.Products
                            .AsNoTracking() // skip the snapshot change tracking for read-only scenarios
                            .ToListAsync();
    }
}
