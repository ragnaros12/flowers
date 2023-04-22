using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asd.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Asd.Controllers;

public class HomeController : Controller
{
    private Database _database;

    public HomeController(Database database)
    {
        _database = database;
    }

    public IActionResult Index()
    {
        return View(_database.Flowers.ToList());
    }
}