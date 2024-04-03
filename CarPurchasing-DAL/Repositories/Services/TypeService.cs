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
public class TypeService: ITypeService  
{
  private CarpurchasingContext _context;
  readonly IConfiguration _config;
  public TypeService(CarpurchasingContext context, IConfiguration config)
  {
      _context = context;
      _config = config;
  }

  public void AddType(ResTypeDto user)
  {
      throw new NotImplementedException();
  }

  public void DeleteType(Guid id)
  {
      throw new NotImplementedException();
  }

  public List<ResTypeDto> GetType()
  {
    try
    {
      var dataType = _context.VwTypes.Select(x => new ResTypeDto
      {
        Id = x.Id,
        Name = x.Name
      }).ToList();
      return dataType;   
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public List<ResMstTypeDto> GetMstType()
  {
    try
    {
      var dataMstType = _context.MstTypes.Select(x => new ResMstTypeDto
      {
        Id = x.Id,
        Name = x.Name
      }).ToList();
      return dataMstType;   
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public void UpdateType(ResTypeDto user)
  {
      throw new NotImplementedException();
  }

  public List<ResTypeDto> SearchType(string username)
  {
      throw new NotImplementedException();
  }

  public async Task<PrcMasterDto> ExecPrcType(
    int? id,
    string name
  )
  {
    try
    {
      string procedureName = "prc_type";
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
