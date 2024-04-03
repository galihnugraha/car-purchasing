using System;
using System.Collections.Generic;

namespace CarPurchasing_DAL.Models;

public partial class VwCustomer
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public string? Occupancy { get; set; }

    public decimal? Salary { get; set; }
}
