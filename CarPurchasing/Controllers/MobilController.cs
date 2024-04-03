using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Repositories.Services.Interfaces;
using CarPurchasing_DAL.Models.Dto.Req;

namespace CarPurchasing.Controllers;

public class MobilController : Controller
{ 
  private readonly IMobilService _service;
  private readonly IBrandService _serviceBrand;
  private readonly ITypeService _serviceType;
  private readonly IUsageService _serviceUsage;
  private readonly IModelService _serviceModel;
  private readonly ICustomerService _serviceCustomer;
  readonly IConfiguration _config;

  [ActivatorUtilitiesConstructor]
  public MobilController(
    IMobilService service,
    IBrandService brand, 
    ITypeService type, 
    IUsageService usage, 
    IModelService model,
    ICustomerService customer,
    IConfiguration config
    )
  {
      _service = service;
      _serviceBrand = brand;
      _serviceType = type;
      _serviceUsage = usage;
      _serviceModel = model;
      _serviceCustomer = customer;
      _config = config;
  }
  public IActionResult Index()
  {
      ViewBag.dataBrand = _serviceBrand.GetMstBrand();
      ViewBag.dataType = _serviceType.GetMstType();
      ViewBag.dataUsage = _serviceUsage.GetMstUsage();
      ViewBag.dataModel = _serviceModel.GetMstModel();
      var dataCar = _service.GetCar();
      return View(dataCar);
  }

  public IActionResult ListMobil()
  {
      ViewBag.dataBrand = _serviceBrand.GetMstBrand();
      ViewBag.dataType = _serviceType.GetMstType();
      ViewBag.dataUsage = _serviceUsage.GetMstUsage();
      ViewBag.dataModel = _serviceModel.GetMstModel();
      ViewBag.dataCustomer = _serviceCustomer.GetMstCustomer();
      var dataCar = _service.GetCar();
      return View(dataCar);
  }

  public IActionResult FormTambahMobil()
  {
    ViewBag.dataBrand = _serviceBrand.GetMstBrand();
    ViewBag.dataType = _serviceType.GetMstType();
    ViewBag.dataUsage = _serviceUsage.GetMstUsage();
    ViewBag.dataModel = _serviceModel.GetMstModel();
    return View();
  }

  [HttpPost]
  public IActionResult TambahMobil(ReqCarDto car)
  {
    if (ModelState.IsValid)
    {
      _service.ExecPrcCar(
        car.Id,
        car.EngineSize,
        car.FuelType,
        car.ManufactureYear,
        car.CdChassis,
        car.CdEngine, 
        car.BrandId,
        car.TypeId,
        car.UsageId,
        car.ModelId
      );
      return RedirectToAction("Index");
    }
    else
    {
      return BadRequest(ModelState);
    }
  }

  [HttpPost]
  public IActionResult EditMobil(ReqCarDto car)
  {
    if (ModelState.IsValid)
    {
      _service.ExecPrcCar(
        car.Id,
        car.EngineSize,
        car.FuelType,
        car.ManufactureYear,
        car.CdChassis,
        car.CdEngine, 
        car.BrandId,
        car.TypeId,
        car.UsageId,
        car.ModelId
      );
      return RedirectToAction("Index");
    }
    else
    {
      return BadRequest(ModelState);
    }
  }

  [HttpDelete]
  [ValidateAntiForgeryToken]
  public IActionResult DeleteMobil([FromForm] ReqCarDto car)
  {
    try
    { 
      _service.DeleteCar((Guid)car.Id);
      return Ok();

    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

}
