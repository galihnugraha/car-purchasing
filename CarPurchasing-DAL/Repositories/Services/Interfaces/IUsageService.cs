using CarPurchasing_DAL.Models.Dto.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Repositories.Services.Interfaces
{
    public interface IUsageService
    {
        void AddUsage(ResUsageDto user);

        List<ResUsageDto> GetUsage();

        List<ResMstUsageDto> GetMstUsage();

        void UpdateUsage(ResUsageDto user);

        void DeleteUsage(Guid id);

        List<ResUsageDto> SearchUsage(string username);

        Task<PrcMasterDto> ExecPrcUsage(
          int? id,
          string name
        );
    }
}
