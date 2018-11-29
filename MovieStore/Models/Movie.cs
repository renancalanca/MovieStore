using MovieStore.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [ReleaseDateBeforeActualDate]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Add Date")]
        public DateTime AddDate { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        [Display(Name = "Stock")]
        public int NumberInStock { get; set; }

        public string Actor { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}