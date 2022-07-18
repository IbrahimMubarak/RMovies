using RMovies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static RMovies.Models.MINAge;

namespace RMovies.DTOS
{

    public class CustomerDto
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        
        public string name { get; set; }
      
        [Required]
        //[MINAge]
        public DateTime birthday { get; set; }
       
        public bool IsSubscribed { get; set; }
       
        [Required]
     
        public byte MembershipTypeId { get; set; }
    }
}