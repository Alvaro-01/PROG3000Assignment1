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
            request.Id = _requestId;
            Repository.AddRequest(request);
            Console.WriteLine($"Request received: {request.Name}, {request.Email}, {request.Id}");
            _requestId++;
            return View("Confirmation", request);
        }
        return View();
    }
    


    public IActionResult AllEquipment()
    {
        var equipmentList = Repository.EquipmentList;

        return View(equipmentList);
    }

    public IActionResult AllAvailableEquipment()
    {
        var availableEquipment = Repository.EquipmentList.Where(e => e.IsAvailable).ToList();

        return View(availableEquipment);
    }

    public IActionResult Requests()
    {
        var requests = Repository.Requests;
        return View(requests);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
