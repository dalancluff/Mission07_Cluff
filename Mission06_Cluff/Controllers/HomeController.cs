using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission06_Cluff.Models;

namespace Mission06_Cluff.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

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

    // ──────────────────────────────────────────────
    // VIEW COLLECTION
    // ──────────────────────────────────────────────
    public IActionResult ViewCollection()
    {
        var movies = _context.Movies
            .Include(m => m.Category)
            .OrderBy(m => m.Title)
            .ToList();

        return View(movies);
    }

    // ──────────────────────────────────────────────
    // ADD MOVIE
    // ──────────────────────────────────────────────
    public IActionResult AddMovie()
    {
        PopulateCategoryDropdown();
        return View();
    }

    [HttpPost]
    public IActionResult AddMovie(Application movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"'{movie.Title}' has been successfully added to your collection!";
            return RedirectToAction("AddMovie");
        }

        PopulateCategoryDropdown(movie.CategoryId);
        return View(movie);
    }

    // ──────────────────────────────────────────────
    // EDIT MOVIE
    // ──────────────────────────────────────────────
    public IActionResult EditMovie(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null) return NotFound();

        PopulateCategoryDropdown(movie.CategoryId);
        return View(movie);
    }

    [HttpPost]
    public IActionResult EditMovie(Application movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"'{movie.Title}' has been updated successfully.";
            return RedirectToAction("ViewCollection");
        }

        PopulateCategoryDropdown(movie.CategoryId);
        return View(movie);
    }

    // ──────────────────────────────────────────────
    // DELETE MOVIE
    // ──────────────────────────────────────────────
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies
            .Include(m => m.Category)
            .FirstOrDefault(m => m.MovieId == id);

        if (movie == null) return NotFound();

        return View(movie);
    }

    [HttpPost, ActionName("DeleteMovie")]
    public IActionResult DeleteMovieConfirmed(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            TempData["SuccessMessage"] = $"'{movie.Title}' has been removed from your collection.";
        }

        return RedirectToAction("ViewCollection");
    }

    // ──────────────────────────────────────────────
    // HELPERS
    // ──────────────────────────────────────────────
    private void PopulateCategoryDropdown(int? selectedId = null)
    {
        ViewBag.Categories = new SelectList(
            _context.Categories.OrderBy(c => c.CategoryName),
            "CategoryId",
            "CategoryName",
            selectedId);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}