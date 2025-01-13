namespace Pizza.Models;

public partial class Order
{
    public int Id { get; set; }

    public string OrderPlaced { get; set; } = null!;

    public string? OrderFulfilled { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
