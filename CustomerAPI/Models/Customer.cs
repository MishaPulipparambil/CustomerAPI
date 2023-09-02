using System;
using System.Collections.Generic;

namespace CustomerAPI.Models;

public partial class Customer
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string PhoneNumber { get; set; }

    public Guid? BillingAddressId { get; set; }

    public Guid MailingAddressId { get; set; }

    public virtual AddressInfo? BillingAddress { get; set; }

    public virtual ICollection<CustomerOrderInfo> CustomerOrderInfos { get; set; } = new List<CustomerOrderInfo>();

    public virtual AddressInfo MailingAddress { get; set; } = null!;
}
