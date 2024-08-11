using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

    private ApplicationDbContext _context;

    public MoviesController()
    {
        _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
    }
    public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movies = new List<Movie>
            {
                new Movie { Name = "Shrek" },
                new Movie { Name = "wall-e" }

            };
            var viewModel = new RandomMovieViewModel
            {
                Movies = movies
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}