using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Repositories.Services.Interfaces;
using CarPurchasing_DAL.Models.Dto.Req;

namespace CarPurchasing.Controllers;

public class TypeController : Controller
{
  private readonly ITypeService _service;

  [ActivatorUtilitiesConstructor]
  public TypeController(ITypeService service)
  {
      _service = service;
  }
  public IActionResult Index()
  {
    var dataType = _service.GetType();
    return View(dataType);
  }
  public IActionResult FormTambahType()
  {
    return View();
  }

  [HttpPost]
  public IActionResult TambahType(ReqTypeDto type)
  {
    if (ModelState.IsValid)
    {
      _service.ExecPrcType(type.Id, type.Name);
      return RedirectToAction("Index");
    }
    else
    {
      return BadRequest(ModelState);
    }
  }
}
