using System.Diagnostics;
using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;
using IntegrationAnalitics.Models;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using IntegrationAnalitics.Application.Domain.Requests.Uploading;
using MediatR;
using IntegrationAnalitics.Application.Models;

namespace IntegrationAnalitics.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApiSmevModel _allMethods;
        

    public HomeController(ILogger<HomeController> logger)
    {                                                       //вошёл в контроллер
        _logger = logger;
        _allMethods = new ApiSmevModel();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult FaqSearch()
    {
        return View("FaqSearch");
    }
    
    //TODO : Алгоритм выгрузки по смеву
    //TODO : Задать начальные перменные для старта выгрузки после прописать алгоритм запросов выгрузки
    //TODO : Получить текст документа, отправить его на фронт, + сделать возможность скачивания

    public IActionResult Uploading()
    {
        return View("Uploading", _allMethods);
    }
    public IActionResult Validation()
    {
        return View("Validation");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Planning()
    {
        return View("Planning");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}