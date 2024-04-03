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
public class ModelService : IModelService
{
  private readonly CarpurchasingContext _context;
  readonly IConfiguration _config;

  public ModelService(CarpurchasingContext context, IConfiguration config)
  {
      _context = context;
      _config = config;
  }
  public void AddModel(ResModelDto user)
  {
      throw new NotImplementedException();
  }

  public List<ResModelDto> GetModel()
  {
    try
    {
      var dataModel = _context.VwModels.Select(x => new ResModelDto
      {
        Id = x.Id,
        Name = x.Name,
        NamaBrand = x.NamaBrand
      }).ToList();
      return dataModel;   
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public List<ResMstModelDto> GetMstModel()
  {
    try
    {
      var dataMstModel = _context.MstModels.Select(x => new ResMstModelDto
      {
        Id = x.Id,
        Name = x.Name
      }).ToList();
      return dataMstModel;   
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public List<ResModelDto> SearchModel(string username)
  {
      throw new NotImplementedException();
  }

  public void UpdateModel(ResModelDto user)
  {
      throw new NotImplementedException();
  }

  public void DeleteModel(Guid id)
  {
    throw new NotImplementedException();
  }

  public async Task<PrcMasterDto> ExecPrcModel(
    int? id,
    string name, 
    int? brandId
  )
  {
    try
    {
      string procedureName = "prc_model";
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
          command.Parameters.AddWithValue("p_brand_id", brandId);

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

