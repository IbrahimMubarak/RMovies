using RMovies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static RMovies.Models.MINAge;

namespace RMovies.Models
{
    public class Customer
    {
        
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Birthdate")]
        [Required]
        [MINAge]
        public DateTime birthday { get; set; }
        [Display(Name = "IsSubscribed")]
        public bool IsSubscribed { get; set; }
        public MembershipType MembershipType { get; set; }
        [Required]
        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}