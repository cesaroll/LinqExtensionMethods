using System;
using System.Collections.Generic;

namespace LinqExtensionMethods.db.Models;

public partial class Customer
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Age { get; set; }
}
