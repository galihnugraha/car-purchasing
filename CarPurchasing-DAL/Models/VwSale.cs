using System;
using System.Collections.Generic;

namespace CarPurchasing_DAL.Models;

public partial class VwSale
{
    public string? Name { get; set; }

    public int? JumlahPenjualan { get; set; }

    public decimal? Komisi { get; set; }
}
