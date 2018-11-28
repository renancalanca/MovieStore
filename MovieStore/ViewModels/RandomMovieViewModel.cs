using System.Collections.Generic;
using MovieStore.Models;

namespace MovieStore.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}