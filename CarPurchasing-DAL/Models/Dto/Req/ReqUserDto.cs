using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Models.Dto.Req
{
    public class ReqUserDto
    {
        public Guid Id { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Status { get; set; }

        public Guid? IdSales { get; set; }

        public DateTime? DtAdded { get; set; }

        public DateTime? DtUpdated { get; set; }
    }
}
