using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Models.Dto.Res
{
    public class ResCustomerDto
    {
      public Guid Id { get; set; }
      
      public string? Name { get; set; }

      public string? Email { get; set; }

      public string? Address { get; set; }

      public string? Gender { get; set; }

      public string? Occupancy { get; set; }

      public decimal? Salary { get; set; }
    }
}
