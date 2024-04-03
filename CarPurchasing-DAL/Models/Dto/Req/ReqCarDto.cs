using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Models.Dto.Req
{
    public class ReqCarDto
    {
        public Guid? Id { get; set; }

        public int? EngineSize { get; set; }

        public string? FuelType { get; set; }

        public int? ManufactureYear { get; set; }

        public string? CdChassis { get; set; }

        public string? CdEngine { get; set; }

        public int? BrandId { get; set; }

        public int? TypeId { get; set; }

        public int? UsageId { get; set; }

        public int? ModelId { get; set; }
    }
}
