using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Models.Dto.Req;
using CarPurchasing_DAL.Models.Dto.Res;
using CarPurchasing_DAL.Repositories.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Repositories.Services
{
    public class UserService: IUserService
    {
        readonly CarpurchasingContext _context;

        public UserService(CarpurchasingContext context)
        {
            _context = context;
        }

        public void AddUser(ReqUserDto user)
        {
            try
            {
                bool isDuplicate = _context.MstUsers.Any(x => x.Username == user.Username);
                if (isDuplicate)
                {
                    throw new Exception("Username sudah ada");
                }
                MstUser newUser = new MstUser
                {
                    Id = Guid.NewGuid(),
                    Username = user.Username,
                    Password = user.Password,
                    Status = "Active",
                    IdSales = user.IdSales,
                    DtAdded = DateTime.Now,
                    DtUpdated = DateTime.Now,

                };
                _context.MstUsers.Add(newUser); 
                _context.SaveChanges();

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ResUserDto> GetUser()
        {
            try
            {
                   var users = _context.VwUsers.Select(x => new ResUserDto
                   {
                       Username = x.Username,
                       Status = x.Status,
                       NamaSales = x.NamaSales,
                   }).ToList();
                return users;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUser(ReqUserDto user)
        {
            try
            {
                _context.MstUsers
                    .Where(u => u.Id == user.Id)
                    .ExecuteUpdate(setter => setter
                        .SetProperty(u => u.Username, user.Username)
                        .SetProperty(u => u.DtUpdated, System.DateTime.Now)
                    );
            }
            catch (Exception ex)
            {
                throw new Exception($"Tidak dapat mengubah data user : {ex.Message}");
            }
        }

        public void DeleteUser(Guid id)
        {
            try
            {
                var dataUser = _context.MstUsers
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                if (dataUser == null)
                {
                    throw new Exception("Data tidak ditemukan");
                }
                _context.Remove(dataUser);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal hapus data: {ex.Message}");
            }
        }

        public List<ResUserDto> SearchUser(string username)
        {
            try
            {
                var users = _context.VwUsers
                    .Where(x => x.Username.Contains(username))
                    .Select(x => new ResUserDto
                    {
                        Username = x.Username,
                        Status = x.Status,
                        NamaSales = x.NamaSales,
                    }).ToList();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
