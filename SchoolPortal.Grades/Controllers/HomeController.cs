using Microsoft.AspNetCore.Mvc;

namespace SchoolPortal.Grades.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => RedirectToAction("Index", "Grades"); 
    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(); 
    }
}