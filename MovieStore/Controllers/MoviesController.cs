using System.Collections.Generic;
using System.Web.Mvc;
using MovieStore.Models;
using MovieStore.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Validation;
using System;

namespace MovieStore.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        //Construtor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Action é o método de uma controller como por exemplo o random, e caso você passe um ID para ele, na URL você também tem que passar
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "One piece" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Renan"},
                new Customer {Name = "Marcos"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);


            //Outros tipos de Retorno
            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name" });

        }

        //Movies/Edit
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            /*http://localhost:54255/movies/edit?id=1 */
            /*http://localhost:54255/movies/edit/1 */


            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);

        }

        //Movies
        //Como colocado no RegisterRoutes a action com nome Index é a que é chamado por padrão quando não especificado nenhuma action na URL
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View();
            else
                return View(RoleName.ReadOnlyList);
        }

        //Definir uma rota especifica
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).FirstOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new MovieFormViewModel(movie)
                    {
                        Genres = _context.Genres.ToList()
                    };

                    return View("MovieForm", viewModel);
                }

                if (movie.Id == 0)
                {
                    movie.AddDate = DateTime.Now;
                    _context.Movies.Add(movie);
                }
                else
                {
                    var movieEdit = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

                    movieEdit.Name = movie.Name;
                    movieEdit.ReleaseDate = movie.ReleaseDate;
                    movieEdit.AddDate = DateTime.Now;
                    movieEdit.Actor = movie.Actor;
                    movieEdit.GenreId = movie.GenreId;
                    movieEdit.NumberInStock = movie.NumberInStock;

                }

                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                return HttpNotFound();
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "Movies");
        }
    }
}