using CarPurchasing_DAL.Models.Dto.Req;
using CarPurchasing_DAL.Models.Dto.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Repositories.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(ReqUserDto user);

        List<ResUserDto> GetUser();

        void UpdateUser(ReqUserDto user);

        void DeleteUser(Guid id);

        List<ResUserDto> SearchUser(string username);
    }
}
