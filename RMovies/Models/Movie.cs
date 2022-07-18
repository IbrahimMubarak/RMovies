using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMovies.Models
{
    public class Movie
    {
        public int id { get; set; }
        [Display(Name = "Movie Name")]
        [Required]
        public string name { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public string genre { get; set; }
        [Display(Name = "Added Date")]
        [Required]
        [AddedDatevalid]
        public DateTime dateAdded { get; set; }
        [Display(Name = "Release Date")]
        [Required]
        [movies_Releasedate]
        public DateTime releseDate { get; set; }
        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1,100,ErrorMessage ="Must between 1 and 100")]
        public int numberinStock { get; set; }
        public int numberAvilable { get; set; }

    }
}