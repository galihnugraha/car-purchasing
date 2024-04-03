using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Models.Dto.Req;
using CarPurchasing_DAL.Models.Dto.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Repositories.Services.Interfaces;

public interface ICustomerService
{
  List<ResCustomerDto> GetCustomer();
  List<ResMstCustomerDto> GetMstCustomer();
  void AddCustomer(ReqCustomerDto user);
  void UpdateCustomer(ReqCustomerDto user);
  void DeleteCustomer(Guid id);
  List<ResCustomerDto> SearchCustomer(string username);
  Task<PrcMasterDto> ExecPrcCustomer(
    Guid? id,
    string name,
    string email,
    string address,
    string gender,
    string occupancy,
    decimal? salary
  );   
}


