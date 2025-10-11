using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;
using Assignment1.Models.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        var equipmentList = _equipmentRepository.GetAvailable(true);
        ViewBag.EquipmentList = equipmentList ?? new List<Equipment>();
        
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
        var equipmentList = _equipmentRepository.GetAvailable(true);
        ViewBag.EquipmentList = equipmentList ?? new List<Equipment>();
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

    [HttpGet]
    public IActionResult Requests()
    {
        var equipmentList = _equipmentRepository.GetAvailable(true);
        ViewBag.EquipmentList = equipmentList ?? new List<Equipment>();
        Console.WriteLine("Fetching all requests...");

        var requests = _requestRepository.GetAll();
        return View(requests);

    }

    [HttpPost]
    public IActionResult AcceptRequest(int id)
    {
        var request = _requestRepository.FindById(id);
        if (request != null && request.Status == RequestStatus.Pending)
        {

            _requestRepository.UpdateStatus(request, RequestStatus.Accepted);

            var equipment = _equipmentRepository.FindById(request.EquipmentId ?? 0);
            if (equipment != null)
            {
                _equipmentRepository.Update(equipment, false);
            }
        }
        return RedirectToAction("Requests");
    }
    
    [HttpPost]
    public IActionResult DeclineRequest(int id)
    {
        var request = _requestRepository.FindById(id);
        if (request != null && request.Status == RequestStatus.Pending)
        {

            _requestRepository.UpdateStatus(request, RequestStatus.Denied);

            var equipment = _equipmentRepository.FindById(request.EquipmentId ?? 0);
            if (equipment != null)
            {
                _equipmentRepository.Update(equipment, true);
            }
        }
        return RedirectToAction("Requests");
    }






    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
