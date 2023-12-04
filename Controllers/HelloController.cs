using Microsoft.AspNetCore.Mvc;

namespace aspnet_hotwire.MVC.Controllers;

public class HelloController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
}
