using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;
using Assignment1.Models.Repository;

namespace Assignment1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IRequestRepository _requestRepository;

    



    public HomeController(ILogger<HomeController> logger, IEquipmentRepository equipmentRepository,
    IRequestRepository requestRepository)
    {
        _logger = logger;
        _equipmentRepository = equipmentRepository;
        _requestRepository = requestRepository;
       
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
    public IActionResult RequestForm()

    {
        
        ViewBag.EquipmentList = _equipmentRepository.GetAvailable(true);
        
        return View();
    }

    [HttpPost]
    public ViewResult RequestForm(EquipmentRequest request)
    {
        if (ModelState.IsValid)
        {
            request.Status = RequestStatus.Pending;
            request.CreatedAt = DateTime.Now;
            _requestRepository.Add(request);
            return View("Confirmation", request);
        }
        return View();
    }
    


    public IActionResult AllEquipment()
    {
        var equipmentList = _equipmentRepository.GetAll();
        return View(equipmentList);
    }

    public IActionResult AllAvailableEquipment()
    {
        var availableEquipment = _equipmentRepository.GetAvailable(true);
        return View(availableEquipment);
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
