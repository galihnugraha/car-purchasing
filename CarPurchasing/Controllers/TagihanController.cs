using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Repositories.Services.Interfaces;
using CarPurchasing_DAL.Models.Dto.Req;

namespace CarPurchasing.Controllers;

public class TagihanController : Controller
{
  private readonly ITagihanService _service;

  [ActivatorUtilitiesConstructor]
  public TagihanController(ITagihanService service)
  {
      _service = service;
  }
  public IActionResult Index()
  {
    var dataTagihan = _service.GetTagihan();
    return View(dataTagihan);
  }
  public IActionResult ListTagihan()
  {
    var dataTagihan = _service.ListTagihan();
    return View(dataTagihan);
  }

  [HttpPost]
  public IActionResult TambahTagihan(ReqTagihanDto tagihan)
  {
    if (ModelState.IsValid)
    {
      _service.ExecPrcTagihan(
        tagihan.Id,
        tagihan.Tenor,
        tagihan.DownPayment,
        tagihan.Price,
        tagihan.Price*(decimal?)0.11,
        tagihan.PaymentStatus,
        tagihan.CustId,
        tagihan.CarId
      );
      return RedirectToAction("Index");
    }
    else
    {
      return BadRequest(ModelState);
    }
  }

  [HttpPost]
  public IActionResult BayarTagihan(ReqTagihanDto tagihan)
  {
    if (ModelState.IsValid)
    {
      _service.ExecPrcTagihan(
        tagihan.Id,
        tagihan.Tenor,
        tagihan.DownPayment,
        tagihan.Price,
        tagihan.Tax,
        tagihan.PaymentStatus,
        tagihan.CustId,
        tagihan.CarId
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
  public IActionResult DeleteTagihan([FromForm] ReqTagihanDto tagihan)
  {
    try
    { 
      _service.DeleteTagihan((Guid)tagihan.Id);
      return Ok();

    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}
