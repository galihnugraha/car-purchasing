using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Repositories.Services.Interfaces;
using CarPurchasing_DAL.Models.Dto.Req;

namespace CarPurchasing.Controllers;

public class UsageController : Controller
{
  private readonly IUsageService _service;

  [ActivatorUtilitiesConstructor]
  public UsageController(IUsageService service)
  {
      _service = service;
  }
  public IActionResult Index()
  {
    var dataUsage = _service.GetUsage();
    return View(dataUsage);
  }

  public IActionResult FormTambahUsage()
  {
    return View();
  }

  [HttpPost]
  public IActionResult TambahUsage(ReqUsageDto type)
  {
    if (ModelState.IsValid)
    {
      _service.ExecPrcUsage(type.Id, type.Name);
      return RedirectToAction("Index");
    }
    else
    {
      return BadRequest(ModelState);
    }
  }
}
