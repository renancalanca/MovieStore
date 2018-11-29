using MovieStore.Models;
using MovieStore.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [ReleaseDateBeforeActualDate]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        [Display(Name = "Stock")]
        public int? NumberInStock { get; set; }

        public string Actor { get; set; }

        [Required]
        public int GenreId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Actor = movie.Actor;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }

    }
}