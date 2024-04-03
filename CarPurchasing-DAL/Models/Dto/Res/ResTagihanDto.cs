using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Models.Dto.Res;
public class ResTagihanDto
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
