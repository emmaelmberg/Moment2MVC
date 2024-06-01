using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moment2MVC.Models;
namespace Moment2MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["ViewDataMessage"] = "En hälsning med ViewData!";

        string message = "En hälsning med ViewBag!";
        ViewBag.message = message;

        return View();
    }

    [HttpGet]
    [Route("/laggtillhundtrick")]
    public IActionResult AddDogtrick()
    {
        return View(new DogtrickModel() { DogName = new DogName()});
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/laggtillhundtrick")]
    public IActionResult AddDogtrick(DogtrickModel model)
    {
        if (ModelState.IsValid)
        {
            string jsonString = System.IO.File.ReadAllText("dogtricks.json");
            var dogtricks = JsonSerializer.Deserialize<List<DogtrickModel>>(jsonString);

            if (dogtricks != null)
            {
                dogtricks.Add(model);
                jsonString = JsonSerializer.Serialize(dogtricks);
                System.IO.File.WriteAllText("dogtricks.json", jsonString);
            }

            ModelState.Clear();

            return RedirectToAction("AddedDogtricks", "Home");
        }
        return View(new DogtrickModel() { DogName = new DogName()});
    }

    [Route("/tillagdahundtrick")]
    public IActionResult AddedDogtricks()
    {
        string jsonString = System.IO.File.ReadAllText("dogtricks.json");
        var dogtricks = JsonSerializer.Deserialize<List<DogtrickModel>>(jsonString);

        return View(dogtricks);
    }

    [Route("/aktiveracookie")]
    public IActionResult SetCookie() {
        HttpContext.Session.SetString("session", "En sessionscookie som varar i 5 sekunder.");
        return View();
    }

    [Route("/aktuellcookie")]
    public IActionResult GetCookie() {
        ViewBag.sessioncontent = HttpContext.Session.GetString("session");

        return View();
    }
}