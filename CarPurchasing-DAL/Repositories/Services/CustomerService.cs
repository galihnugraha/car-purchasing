using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Models.Dto.Req;
using CarPurchasing_DAL.Models.Dto.Res;
using CarPurchasing_DAL.Repositories.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPurchasing_DAL.Repositories.Services;
public class CustomerService: ICustomerService
{
  readonly CarpurchasingContext _context;
  private readonly IConfiguration _config;

  public CustomerService(CarpurchasingContext context, IConfiguration configuration)
  {
    _context = context;
    _config = configuration;
  }
  public void AddCustomer(ReqCustomerDto Customer)
  {
    throw new NotImplementedException();
  }

  public List<ResCustomerDto> GetCustomer()
  {
      try
      {
          var dataMobil = _context.VwCustomers.Select(x => new ResCustomerDto
          {
              Id = x.Id,
              Name = x.Name,
              Email = x.Email,
              Address = x.Address,
              Gender = x.Gender,
              Occupancy = x.Occupancy,
              Salary = x.Salary
          }).ToList();
          return dataMobil;   
      } catch (Exception ex)
      {
          throw new Exception(ex.Message);
      }
  }

  public List<ResMstCustomerDto> GetMstCustomer()
  {
    try
    {
      var dataMstCustomer = _context.MstCustomers.Select(x => new ResMstCustomerDto
      {
        Id = x.Id,
        Name = x.Name
      }).ToList();
      return dataMstCustomer;   
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public void UpdateCustomer(ReqCustomerDto Customer)
  {
      throw new NotImplementedException();
  }

  public void DeleteCustomer(Guid id)
  {
    try
    {
      var dataCustomer = _context.MstCustomers.FirstOrDefault(x => x.Id == id);
      if (dataCustomer == null)
      {
          throw new Exception("Data tidak ditemukan");
      }
      _context.MstCustomers.Remove(dataCustomer);
      _context.SaveChanges();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public List<ResCustomerDto> SearchCustomer(string Customername)
  {
      throw new NotImplementedException();
  }

  public async Task<PrcMasterDto> ExecPrcCustomer(
    Guid? id,
    string name,
    string email,
    string address,
    string gender,
    string occupancy,
    decimal? salary
  )  
  {
    try
    {
      string procedureName = "prc_customer";
      string connectionString = _config.GetConnectionString("DefaultConnection") ?? "";
      PrcMasterDto model = new PrcMasterDto();

      using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
      {
        using (NpgsqlCommand command = new NpgsqlCommand(procedureName, connection))
        {
          command.CommandType = System.Data.CommandType.StoredProcedure;
          command.CommandText = procedureName;

          // command.Parameters.AddWithValue("p_id", id);
          if (id.HasValue)
          {
              command.Parameters.AddWithValue("p_id", id.Value);
          }
          else
          {
              command.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlDbType.Uuid) { Value = DBNull.Value });
          }
          command.Parameters.AddWithValue("p_name", name);
          command.Parameters.AddWithValue("p_email", email);
          command.Parameters.AddWithValue("p_address", address);
          command.Parameters.AddWithValue("p_gender", gender);
          command.Parameters.AddWithValue("p_occupancy", occupancy);
          command.Parameters.AddWithValue("p_salary", salary);          

          // Tambahkan parameter untuk OUT_MESS
          command.Parameters.Add(new NpgsqlParameter("out_mess", NpgsqlTypes.NpgsqlDbType.Varchar, 100)
          {
            Direction = System.Data.ParameterDirection.Output
          });

          // Buka koneksi dan jalankan perintah
          connection.Open();
          command.ExecuteNonQuery();
          
          // Menerapkan output pada model
          model.MESSAGE = command.Parameters["out_mess"].Value != DBNull.Value ? command.Parameters["out_mess"].Value.ToString() : "No value";
        
          return model;
        }
      }
    }
    catch (Exception e)
    {
      throw new ArgumentException($"ExecPrc : {e.Message}");
    }
  }
}

