using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarPurchasing_DAL.Models;

namespace CarPurchasing.Controllers;

public class AuthController : Controller
{
  public IActionResult Index()
  {
    return RedirectToAction("Login");
  }
  
  public IActionResult Login()
  {
    return View();
  }
}
