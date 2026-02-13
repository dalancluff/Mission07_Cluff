using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Cluff.Models;

namespace Mission06_Cluff.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    // Constructor with dependency injection
    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult MeetJoel()
    {
        return View();
    }
    
    // GET: Display the Add Movie form
    public IActionResult AddMovie()
    {
        return View();
    }

    // POST: Handle form submission and save to database
    [HttpPost]
    public IActionResult AddMovie(Application movie)
    {
        if (ModelState.IsValid)
        {
            // Add the movie to the database
            _context.Movies.Add(movie);
            _context.SaveChanges();
            
            // Set success message
            TempData["SuccessMessage"] = $"'{movie.Title}' has been successfully added to your collection!";
            
            // Redirect back to the form (this clears the form)
            return RedirectToAction("AddMovie");
        }
        
        // If validation fails, return to the form with errors
        return View(movie);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}