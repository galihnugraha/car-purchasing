using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarPurchasing_DAL.Models;

namespace CarPurchasing.Controllers;

public class UserController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
}
