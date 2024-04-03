using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Models.Dto.Res;
using CarPurchasing_DAL.Repositories.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasing_DAL.Repositories.Services;
public class UsageService: IUsageService
{
  private CarpurchasingContext _context;
  readonly IConfiguration _config;

  public UsageService(CarpurchasingContext context, IConfiguration config)
  {
      _context = context;
      _config = config;
  }

  public void AddUsage(ResUsageDto user)
  {
      throw new NotImplementedException();
  }

  public void DeleteUsage(Guid id)
  {
      throw new NotImplementedException();
  }

  public List<ResUsageDto> GetUsage()
  {
    try
    {
      var dataUsage = _context.VwUsages.Select(x => new ResUsageDto
      {
        Id = x.Id,
        Name = x.Name
      }).ToList();
      return dataUsage;   
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public List<ResMstUsageDto> GetMstUsage()
  {
    try
    {
      var dataMstUsage = _context.MstUsages.Select(x => new ResMstUsageDto
      {
        Id = x.Id,
        Name = x.Name
      }).ToList();
      return dataMstUsage;   
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public void UpdateUsage(ResUsageDto user)
  {
      throw new NotImplementedException();
  }

  public List<ResUsageDto> SearchUsage(string username)
  {
      throw new NotImplementedException();
  }

  public async Task<PrcMasterDto> ExecPrcUsage(
    int? id,
    string name
  )
  {
    try
    {
      string procedureName = "prc_usage";
      string connectionString = _config.GetConnectionString("DefaultConnection") ?? "";
      PrcMasterDto model = new PrcMasterDto();

      using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
      {
        using (NpgsqlCommand command = new NpgsqlCommand(procedureName, connection))
        {
          command.CommandType = System.Data.CommandType.StoredProcedure;
          command.CommandText = procedureName;

          command.Parameters.AddWithValue("p_id", id);
          command.Parameters.AddWithValue("p_name", name);

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
