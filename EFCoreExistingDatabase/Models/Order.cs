using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExistingDatabase.Models;

[Index("CustomerId", Name = "IX_Orders_CustomerId")]
public partial class Order
{
    [Key]
    public int Id { get; set; }

    public string OrderPlaced { get; set; } = null!;

    public string? OrderFulfilled { get; set; }

    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Orders")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
