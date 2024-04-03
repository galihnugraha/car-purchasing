using CarPurchasing_DAL.Models.Dto.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Repositories.Services.Interfaces
{
    public interface ITypeService
    {
        void AddType(ResTypeDto user);

        List<ResTypeDto> GetType();

        List<ResMstTypeDto> GetMstType();

        void UpdateType(ResTypeDto user);

        void DeleteType(Guid id);

        // List<ResTypeDto> SearchType(string username);

        Task<PrcMasterDto> ExecPrcType(
          int? id,
          string name
        );
    }
}
