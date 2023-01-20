using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IntegrationAnalitics.Models;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

    //<?xml version="1.0" encoding="UTF-8"?>
    // <UNPDocument
    //     xmlns:xsd="http://www.w3.org/2001/XMLSchema"
    // xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    // xmlns="urn://x-artefacts-minfin-unp/1.13.0">
    // <DocumentNumber>148</DocumentNumber>
    // <DocumentType>9</DocumentType>
    // <CreateNew>true</CreateNew>
    // </UNPDocument>
    //https://unp.bars.group/release/api/smev
    public IActionResult Uploading()
    {
        async void GetXmlHandler()
        {
            using var client = new HttpClient();
            string request = JsonConvert.SerializeObject(new Dictionary<string, object> { {"param", "<?xml version='1.0' encoding='UTF-8'?><UNPDocument xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn://x-artefacts-minfin-unp/1.13.0'><DocumentNumber>148</DocumentNumber><DocumentType>9</DocumentType><CreateNew>true</CreateNew></UNPDocument>"} });
            var stringContent = new StringContent(request);
            var result = await client.PostAsync("https://unp.bars.group/release/api/smev", stringContent);
            using (var sr = new StreamReader(await result.Content.ReadAsStreamAsync(), Encoding.GetEncoding("iso-8859-1")))
            {
                string s = sr.ReadToEnd();
                Console.WriteLine(s.Substring(0, 1000));
            }
        }
        GetXmlHandler();

        //TODO : Алгоритм выгрузки по смеву
        //TODO : Задать начальные перменные для старта выгрузки после прописать алгоритм запросов выгрузки
        //TODO : Получить текст документа, отправить его на фронт, + сделать возможность скачивания

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