using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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
        public ActionResult Edit(int id)
        {
            /*http://localhost:54255/movies/edit?id=1 */
            /*http://localhost:54255/movies/edit/1 */

            return Content("id= " + id);
        }

        //Movies
        //Como colocado no RegisterRoutes a action com nome Index é a que é chamado por padrão quando não especificado nenhuma action na URL
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = new MoviesViewModel();

            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrEmpty(sortBy))
            {
                movies.Movies = new List<Movie>
                {
                    new Movie { Name = "Sherek" },
                    new Movie { Name = "One Piece" }
                };
            }

            return View(movies);
            //return Content("pageIndex = " + pageIndex + " & sortBy = " + sortBy);
        }

        //Definir uma rota especifica
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}