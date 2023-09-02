using System;
using System.Collections.Generic;

namespace CustomerAPI.Models;

public partial class CustomerOrderInfo
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid ProductId { get; set; }

    public int Count { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
