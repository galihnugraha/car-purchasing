using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Models.Dto.Req;
using CarPurchasing_DAL.Repositories.Services.Interfaces;

namespace CarPurchasing.Controllers;

public class CustomerController : Controller
{
  private readonly ICustomerService _service;

  [ActivatorUtilitiesConstructor]
  public CustomerController(ICustomerService service)
  {
      _service = service;
  }
  public IActionResult Index()
  {
    var dataCustomer = _service.GetCustomer();
    return View(dataCustomer);
  }
  public IActionResult FormTambahCustomer()
  {
    return View();
  }

  [HttpPost]
  public IActionResult TambahCustomer(ReqCustomerDto customer)
  {
    if (ModelState.IsValid)
    {
      _service.ExecPrcCustomer(
        customer.Id,
        customer.Name,
        customer.Email,
        customer.Address,
        customer.Gender,
        customer.Occupancy,
        customer.Salary
      );
      return RedirectToAction("Index");
    }
    else
    {
      return BadRequest(ModelState);
    }
  }
  [HttpPost]
  public IActionResult EditCustomer(ReqCustomerDto customer)
  {
    if (ModelState.IsValid)
    {
      _service.ExecPrcCustomer(
        customer.Id,
        customer.Name,
        customer.Email,
        customer.Address,
        customer.Gender,
        customer.Occupancy,
        customer.Salary
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
  public IActionResult DeleteCustomer([FromForm] ReqCustomerDto customer)
  {
    try
    { 
      _service.DeleteCustomer((Guid)customer.Id);
      return Ok();

    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}
