using CarPurchasing_DAL.Models.Dto.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Repositories.Services.Interfaces;
  public interface IModelService
  {
    void AddModel(ResModelDto user);

    List<ResModelDto> GetModel();

    List<ResMstModelDto> GetMstModel();

    void UpdateModel(ResModelDto user);

    void DeleteModel(Guid id);

    // List<ResModelDto> SearchModel(string username);

    Task<PrcMasterDto> ExecPrcModel(
      int? id,
      string name, 
      int? brandId
    );

  }
