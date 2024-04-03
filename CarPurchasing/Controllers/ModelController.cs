using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Repositories.Services.Interfaces;
using CarPurchasing_DAL.Models.Dto.Req;

namespace CarPurchasing.Controllers;

public class ModelController : Controller
{
  private readonly IModelService _service;
  private readonly IBrandService _serviceBrand;
  readonly IConfiguration _config;

  [ActivatorUtilitiesConstructor]
  public ModelController(IModelService service, IBrandService brand, IConfiguration config)
  {
      _service = service;
      _serviceBrand = brand;
      _config = config;
  }
  public IActionResult Index()
  {
    var dataModel = _service.GetModel();
    return View(dataModel);
  }

  public IActionResult FormTambahModel()
  {
    ViewBag.dataBrand = _serviceBrand.GetMstBrand();
    return View();
  }

  [HttpPost]
  public IActionResult TambahModel(ReqModelDto type)
  {
    if (ModelState.IsValid)
    {
      _service.ExecPrcModel(type.Id, type.Name, type.BrandId);
      return RedirectToAction("Index");
    }
    else
    {
      return BadRequest(ModelState);
    }
  }
}
