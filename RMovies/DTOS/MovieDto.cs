using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMovies.DTOS
{
    public class MovieDto
    {
        public int id { get; set; }
       
        [Required]
        public string name { get; set; }
        
        [Required]
        public string genre { get; set; } 
        [Required]
        //[AddedDatevalid]
        public DateTime dateAdded { get; set; } 
        [Required]
        //[movies_Releasedate]
        public DateTime releseDate { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Must between 1 and 100")]
        public int numberinStock { get; set; }
    }
}