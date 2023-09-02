using System;
using System.Collections.Generic;

namespace CustomerAPI.Models;

public partial class State
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<AddressInfo> AddressInfos { get; set; } = new List<AddressInfo>();
}
