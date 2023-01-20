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
    //TODO : Алгоритм выгрузки по смеву
    //TODO : Задать начальные перменные для старта выгрузки после прописать алгоритм запросов выгрузки
    //TODO : Получить текст документа, отправить его на фронт, + сделать возможность скачивания
    public async Task<IActionResult> Uploading()
    {
        using var client = new HttpClient();
        var message = new HttpRequestMessage();
        message.Content = new StringContent("<?xml version='1.0' encoding='UTF-8'?><UNPDocument xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn://x-artefacts-minfin-unp/1.13.0'><DocumentNumber>148</DocumentNumber><DocumentType>9</DocumentType><CreateNew>true</CreateNew></UNPDocument>");
        client.BaseAddress = new Uri("https://unp.bars.group/release/api/smev");
        var result = await client.SendAsync(message);
        
        using (var sr = new StreamReader(await result.Content.ReadAsStreamAsync(), Encoding.GetEncoding("utf-8")))
        {
            string s = sr.ReadToEnd();
            string path = @"..\IntegrationAnalitics\obj\Debug\net6.0\Response.xml";   
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(s);
                await fstream.WriteAsync(buffer, 0, buffer.Length);
            }
        }

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