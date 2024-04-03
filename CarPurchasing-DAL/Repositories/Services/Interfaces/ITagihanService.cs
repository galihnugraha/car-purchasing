using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Models.Dto.Req;
using CarPurchasing_DAL.Models.Dto.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Repositories.Services.Interfaces;

public interface ITagihanService
{
  List<ResTagihanDto> GetTagihan();
  List<ResTagihanDto> ListTagihan();
  void AddTagihan(ReqTagihanDto user);
  void UpdateTagihan(ReqTagihanDto user);
  void DeleteTagihan(Guid id);
  List<ResTagihanDto> SearchTagihan(string username);
  Task<PrcMasterDto> ExecPrcTagihan(
    Guid? id,
    int? tenor,
    decimal? downPayment,
    decimal? price,
    decimal? tax,
    string? paymentStatus,
    Guid? custId,
    Guid? carId
  ); 
}


