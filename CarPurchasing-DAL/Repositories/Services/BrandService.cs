using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Models.Dto.Req;
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
public class BrandService: IBrandService
{
  private readonly CarpurchasingContext _context;
  readonly IConfiguration _config;

  public BrandService(CarpurchasingContext context, IConfiguration config)
  {
      _context = context;
      _config = config;
  }
  public void AddBrand(ReqBrandDto brand)
  {
      throw new NotImplementedException();
  }  

  public List<ResBrandDto> GetBrand()
  {
    try
    {
      var dataBrand = _context.VwBrands.Select(x => new ResBrandDto
      {
        Id = x.Id,
        Name = x.Name,
        Country = x.Country,
      }).ToList();
      return dataBrand;   
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public List<ResMstBrandDto> GetMstBrand()
  {
    try
    {
      var dataMstBrand = _context.MstBrands.Select(x => new ResMstBrandDto
      {
        Id = x.Id,
        Name = x.Name
      }).ToList();
      return dataMstBrand;   
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public List<ResBrandDto> SearchBrand(string username)
  {
      throw new NotImplementedException();
  }

  public void UpdateBrand(ReqBrandDto user)
  {
      throw new NotImplementedException();
  }

  public void DeleteBrand(Guid id)
  {
      throw new NotImplementedException();
  }

  public async Task<PrcMasterDto> ExecPrcBrand(
    int? id,
    string name, 
    string country
  )
  {
    try
    {
      string procedureName = "prc_brand";
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
          command.Parameters.AddWithValue("p_country", country);

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
