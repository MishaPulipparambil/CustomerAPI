using System;
using System.Collections.Generic;

namespace CustomerAPI.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Cost { get; set; }

   // public virtual ICollection<CustomerOrderInfo> CustomerOrderInfos { get; set; } = new List<CustomerOrderInfo>();
}
