using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreExistingDatabase.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(6, 2)")]
    public decimal Price { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = [];
}
