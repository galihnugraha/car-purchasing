
using CarPurchasing_DAL.Models.Dto.Req;
using CarPurchasing_DAL.Models.Dto.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Repositories.Services.Interfaces
{
    public interface IBrandService
    {
        void AddBrand(ReqBrandDto user);

        List<ResBrandDto> GetBrand();

        List<ResMstBrandDto> GetMstBrand();

        void UpdateBrand(ReqBrandDto user);

        void DeleteBrand(Guid id);

        Task<PrcMasterDto> ExecPrcBrand(
          int? id,
          string name, 
          string country
        );

        // List<ResBrandDto> SearchBrand(string username);
    }
}
