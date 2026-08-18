using FlamesMVC.Models;
using FlamesMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlamesMvc.Controllers;

public class HomeController : Controller
{
    private readonly FlamesService _flamesService;

    public HomeController(FlamesService flamesService)
    {
        _flamesService = flamesService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new Inputs());
    }

    [HttpPost]
    public IActionResult Index(Inputs input)
    {
        if (string.IsNullOrWhiteSpace(input.YourName) ||
            string.IsNullOrWhiteSpace(input.PartnerName))
        {
            ModelState.AddModelError(
                "",
                "Please enter both names.");

            return View(input);
        }

        input.Result = _flamesService.Calculate(
            input.YourName,
            input.PartnerName);

        return View(input);
    }
}