using Asd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Asd.Controllers;

public class FlowerController : Controller
{
    private Database _database;

    public FlowerController(Database database)
    {
        _database = database;
    }
    
    public IActionResult Add(List<ModelError>? errors, CreationFlower? flower)
    {
        ViewBag.errors = errors == null ? new List<ModelError>() : errors;
        return View(flower);
    }

    [HttpPost]
    public IActionResult Add(CreationFlower flower)
    {
        if (ModelState.IsValid)
        {
            var fileName = "flowerImages/" + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") +
                           Path.GetExtension(flower.Image.FileName);
            FileStream fileStream = System.IO.File.Create("wwwroot/" + fileName);
            flower.Image.CopyTo(fileStream);
            fileStream.Close();
            
            _database.Flowers.Add(new Flower
            {
                Description = flower.Description,
                Height = flower.Height,
                Price = flower.Price,
                Image = fileName,
                Name = flower.Name,
                Compound = flower.Compound,
                Width = flower.Width
            });
            _database.SaveChanges();
            return Redirect("Home/Index");
        }

        return Add(ModelState.Values.SelectMany(v => v.Errors).ToList(), flower);
    }

    public IActionResult Flower(int id)
    {
        var flower = _database.Flowers.Where(u => u.Id == id);
        if (!flower.Any())
            return NotFound();
        return View(flower.First());
    }
}