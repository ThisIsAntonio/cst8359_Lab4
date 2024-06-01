using Microsoft.AspNetCore.Mvc;
using Lab4.Models;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SongForm() => View();

        [HttpPost]
        public IActionResult Sing()
        {
            // TryParse para manejar posibles errores de conversión de datos
            if (int.TryParse(Request.Form["numMonkeys"], out int numberOfMonkeys))
            {
                if (numberOfMonkeys >= 50 && numberOfMonkeys <= 100)
                {
                    ViewBag.NumberOfMonkeys = numberOfMonkeys;
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Number of monkeys must be between 50 and 100.");
                    return View("SongForm");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid number format.");
                return View("SongForm");
            }
        }

        public IActionResult CreateStudent() => View();

        [HttpPost]
        public IActionResult DisplayStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                return View(student);
            }
            return View("CreateStudent");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
