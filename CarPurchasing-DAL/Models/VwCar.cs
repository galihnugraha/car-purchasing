using System;
using System.Collections.Generic;

namespace CarPurchasing_DAL.Models;

public partial class VwCar
{
    public Guid Id { get; set; }
    public int? EngineSize { get; set; }

    public string? FuelType { get; set; }

    public int? ManufactureYear { get; set; }

    public string? CdChassis { get; set; }

    public string? CdEngine { get; set; }

    public string? NamaBrand { get; set; }

    public string? NamaType { get; set; }

    public string? NamaUsage { get; set; }

    public string? NamaModel { get; set; }
}
