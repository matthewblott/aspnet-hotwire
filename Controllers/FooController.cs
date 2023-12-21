using Microsoft.AspNetCore.Mvc;

namespace aspnet_hotwire.MVC.Controllers;

public class FooController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
}
