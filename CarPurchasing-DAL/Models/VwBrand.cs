using System;
using System.Collections.Generic;

namespace CarPurchasing_DAL.Models;

public partial class VwBrand
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public string? Country { get; set; }
}
