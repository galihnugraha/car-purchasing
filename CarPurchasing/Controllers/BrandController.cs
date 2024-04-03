using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Repositories.Services.Interfaces;
using CarPurchasing_DAL.Models.Dto.Req;

namespace CarPurchasing.Controllers;

public class BrandController : Controller
{
  private readonly IBrandService _service;

  [ActivatorUtilitiesConstructor]
  public BrandController(IBrandService service)
  {
      _service = service;
  }
  public IActionResult Index()
  {
      var dataBrand = _service.GetBrand();
      return View(dataBrand);
  }

  public IActionResult FormTambahBrand()
  {
    return View();
  }

  [HttpPost]
  public IActionResult TambahBrand(ReqBrandDto brand)
  {
    if (ModelState.IsValid)
    {
      _service.ExecPrcBrand(brand.Id, brand.Name, brand.Country);
      return RedirectToAction("Index");
    }
    else
    {
      return BadRequest(ModelState);
    }
  }
}
