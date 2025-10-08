using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static int _requestId;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public ViewResult RequestForm()
    {
        return View();
    }

    [HttpPost]
    public ViewResult RequestForm(EquipmentRequest request)
    {
        if (ModelState.IsValid)
        {
            
        }
        return View();
    }
    


    public IActionResult AllEquipment()
    {
        return View();
    }

    public IActionResult AllAvailableEquipment()
    {
        return View();
    }

    public IActionResult Requests()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
