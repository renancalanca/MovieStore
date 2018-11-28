using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime AddDate { get; set; }
        public int NumberInStock { get; set; }
        public string Actor { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}