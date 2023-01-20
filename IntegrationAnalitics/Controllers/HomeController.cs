using System.Diagnostics;
using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;
using IntegrationAnalitics.Models;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace IntegrationAnalitics.Controllers;

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

    public IActionResult FaqSearch()
    {
        return View("FaqSearch");
    }
    
    //TODO : Алгоритм выгрузки по смеву
    //TODO : Задать начальные перменные для старта выгрузки после прописать алгоритм запросов выгрузки
    //TODO : Получить текст документа, отправить его на фронт, + сделать возможность скачивания
    public async Task<IActionResult> Uploading()
    {
        return View("Uploading");
    }

    public IActionResult Validation()
    {
        return View("Validation");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}