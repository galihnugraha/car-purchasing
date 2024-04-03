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
public class TagihanService: ITagihanService
{
  readonly CarpurchasingContext _context;
  private readonly IConfiguration _config;

  public TagihanService(CarpurchasingContext context, IConfiguration configuration)
  {
      _context = context;
      _config = configuration;
  }
  public void AddTagihan(ReqTagihanDto tagihan)
  {
    throw new NotImplementedException();
  }

  public List<ResTagihanDto> GetTagihan()
  {
      try
      {
          var dataTagihan = _context.VwTagihans.Select(x => new ResTagihanDto
          {
              Id = x.Id,
              Tenor = x.Tenor,
              DownPayment = x.DownPayment,
              Tax = x.Tax,
              Price = x.Price,
              PaymentStatus = x.PaymentStatus,
              CarId = x.CarId,
              CustId = x.CustId,
              NamaBrand = x.NamaBrand,
              NamaModel = x.NamaModel,
              NamaCust = x.NamaCust
          }).ToList();
          return dataTagihan;   
      } catch (Exception ex)
      {
          throw new Exception(ex.Message);
      }

  }
  public List<ResTagihanDto> ListTagihan()
  {
      try
      {
          var dataTagihan = _context.VwTagihans
            .Where(x => x.PaymentStatus == "BOOKED")
            .Select(x => new ResTagihanDto
          {
              Id = x.Id,
              Tenor = x.Tenor,
              DownPayment = x.DownPayment,
              Tax = x.Tax,
              Price = x.Price,
              PaymentStatus = x.PaymentStatus,
              CarId = x.CarId,
              CustId = x.CustId,
              NamaBrand = x.NamaBrand,
              NamaModel = x.NamaModel,
              NamaCust = x.NamaCust
          }).ToList();
          return dataTagihan;   
      } catch (Exception ex)
      {
          throw new Exception(ex.Message);
      }

  }

  public void UpdateTagihan(ReqTagihanDto tagihan)
  {
      throw new NotImplementedException();
  }

  public void DeleteTagihan(Guid id)
  {
    try
    {
      var dataTagihan = _context.TrnCarPurchases.FirstOrDefault(x => x.Id == id);
      if (dataTagihan == null)
      {
          throw new Exception("Data tidak ditemukan");
      }
      _context.TrnCarPurchases.Remove(dataTagihan);
      _context.SaveChanges();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public List<ResTagihanDto> SearchTagihan(string Carname)
  {
      throw new NotImplementedException();
  }

  public List<ResCarDto> SearchCar(string Carname)
  {
      throw new NotImplementedException();
  }

  public async Task<PrcMasterDto> ExecPrcTagihan(
    Guid? id,
    int? tenor,
    decimal? downPayment,
    decimal? price,
    decimal? tax,
    string? paymentStatus,
    Guid? custId,
    Guid? carId
  )  
  {
    try
    {
      string procedureName = "prc_tagihan";
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
          // command.Parameters.AddWithValue("p_tenor", tenor);
          // command.Parameters.AddWithValue("p_down_payment", downPayment);
          // command.Parameters.AddWithValue("p_tax", tax);
          // command.Parameters.AddWithValue("p_price", price);
          // command.Parameters.AddWithValue("p_payment_status", paymentStatus);
          // command.Parameters.AddWithValue("p_cust_id", custId);
          // command.Parameters.AddWithValue("p_car_id", carId);
          command.Parameters.AddWithValue("p_tenor", tenor ?? (object)DBNull.Value);
          command.Parameters.AddWithValue("p_down_payment", downPayment ?? (object)DBNull.Value);
          command.Parameters.AddWithValue("p_tax", tax ?? (object)DBNull.Value);
          command.Parameters.AddWithValue("p_price", price ?? (object)DBNull.Value);
          command.Parameters.AddWithValue("p_payment_status", paymentStatus ?? (object)DBNull.Value);
          command.Parameters.AddWithValue("p_cust_id", custId ?? (object)DBNull.Value);
          command.Parameters.AddWithValue("p_car_id", carId ?? (object)DBNull.Value);

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

