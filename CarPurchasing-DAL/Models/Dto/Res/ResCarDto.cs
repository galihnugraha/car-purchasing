using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Models.Dto.Res
{
    public class ResCarDto
    {
        public Guid? Id { get; set; }

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
}
