using System;
using System.Collections.Generic;

namespace CarPurchasing_DAL.Models;

public partial class VwTagihan
{
    public Guid? Id { get; set; }

    public int? Tenor { get; set; }

    public decimal? DownPayment { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Price { get; set; }

    public string? PaymentStatus { get; set; }

    public Guid? CarId { get; set; }

    public Guid? CustId { get; set; }

    public string? NamaBrand { get; set; }

    public string? NamaModel { get; set; }

    public string? NamaCust { get; set; }
}
