using System;
using System.Collections.Generic;

namespace CustomerAPI.Models;

public partial class AddressInfo
{
    public Guid Id { get; set; }

    public string StreetAddress1 { get; set; } = null!;

    public string? StreetAddress2 { get; set; }

    public string? AptmntOrUnitNo { get; set; }

    public string City { get; set; } = null!;

    public int StateId { get; set; }

    public string? ZipCode { get; set; }

    public virtual ICollection<Customer> CustomerBillingAddresses { get; set; } = new List<Customer>();

    public virtual ICollection<Customer> CustomerMailingAddresses { get; set; } = new List<Customer>();

    public virtual State State { get; set; } = null!;
}
