using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

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
            Repository.AddRequest(request);
            return View("Confirmation", request);
        }
        return View();
    }



    public IActionResult AllEquipment()
    {
        var equipmentList = new List<Equipment>
        {
            new Equipment { Id = 1, Type = "Laptop", Description = "Dell XPS 13", IsAvailable = true },
            new Equipment { Id = 2, Type = "Projector", Description = "Epson EX3260", IsAvailable = false },
            new Equipment { Id = 3, Type = "Camera", Description = "Canon EOS Rebel T7", IsAvailable = true },
            new Equipment { Id = 4, Type = "Microphone", Description = "Blue Yeti USB Microphone", IsAvailable = true },
            new Equipment { Id = 5, Type = "Tablet", Description = "iPad Pro 11-inch", IsAvailable = false }
        };

        return View(equipmentList);
    }

    public IActionResult AllAvailableEquipment()
    {
        var equipmentList = new List<Equipment>
        {
            new Equipment { Id = 1, Type = "Laptop", Description = "Dell XPS 13", IsAvailable = true },
            new Equipment { Id = 2, Type = "Projector", Description = "Epson EX3260", IsAvailable = false },
            new Equipment { Id = 3, Type = "Camera", Description = "Canon EOS Rebel T7", IsAvailable = true },
            new Equipment { Id = 4, Type = "Microphone", Description = "Blue Yeti USB Microphone", IsAvailable = true },
            new Equipment { Id = 5, Type = "Tablet", Description = "iPad Pro 11-inch", IsAvailable = false }
        };

        return View(equipmentList);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
