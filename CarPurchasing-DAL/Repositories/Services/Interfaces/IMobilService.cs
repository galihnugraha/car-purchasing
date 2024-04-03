using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Models.Dto.Req;
using CarPurchasing_DAL.Models.Dto.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Repositories.Services.Interfaces;

public interface IMobilService
{
  List<ResCarDto> GetCar();
  void AddCar(ReqCarDto user);
  void UpdateCar(ReqCarDto user);
  void DeleteCar(Guid id);
  List<ResCarDto> SearchCar(string username);
  Task<PrcMasterDto> ExecPrcCar(
    Guid? id, 
    int? engineSize, 
    string fuelType, 
    int? manufactureYear, 
    string cdChassis, 
    string cdEngine, 
    int? brandId, 
    int? typeId, 
    int? usageId, 
    int? modelId
  );   
}


