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
public class MobilService: IMobilService
{
  readonly CarpurchasingContext _context;
  private readonly IConfiguration _config;

  public MobilService(CarpurchasingContext context, IConfiguration configuration)
  {
    _context = context;
    _config = configuration;
  }
  public void AddCar(ReqCarDto Car)
  {
    throw new NotImplementedException();
  }

  public List<ResCarDto> GetCar()
  {
      try
      {
          var dataMobil = _context.VwCars.Select(x => new ResCarDto
          {
              Id = x.Id,  
              EngineSize = x.EngineSize,
              FuelType = x.FuelType,
              ManufactureYear = x.ManufactureYear,
              CdChassis = x.CdChassis,
              CdEngine = x.CdEngine,
              NamaBrand = x.NamaBrand,
              NamaType = x.NamaType,
              NamaUsage = x.NamaUsage,
              NamaModel = x.NamaModel
          }).ToList();
          return dataMobil;   
      } catch (Exception ex)
      {
          throw new Exception(ex.Message);
      }

  }

  public void UpdateCar(ReqCarDto Car)
  {
      throw new NotImplementedException();
  }

  public void DeleteCar(Guid id)
  {
    try
    {
      var dataCar = _context.MstCars.FirstOrDefault(x => x.Id == id);
      if (dataCar == null)
      {
          throw new Exception("Data tidak ditemukan");
      }
      _context.MstCars.Remove(dataCar);
      _context.SaveChanges();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public List<ResCarDto> SearchCar(string Carname)
  {
      throw new NotImplementedException();
  }

  public async Task<PrcMasterDto> ExecPrcCar(
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
  )  
  {
    try
    {
      string procedureName = "prc_car";
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
          command.Parameters.AddWithValue("p_engine_size", engineSize);
          command.Parameters.AddWithValue("p_fuel_type", fuelType);
          command.Parameters.AddWithValue("p_manufacture_year", manufactureYear);
          command.Parameters.AddWithValue("p_cd_chassis", cdChassis);
          command.Parameters.AddWithValue("p_cd_engine", cdEngine);
          command.Parameters.AddWithValue("p_brand_id", brandId);
          command.Parameters.AddWithValue("p_type_id", typeId);
          command.Parameters.AddWithValue("p_usage_id", usageId);
          command.Parameters.AddWithValue("p_model_id", modelId);

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

