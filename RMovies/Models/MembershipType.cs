using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMovies.Models
{
    public class MembershipType
    {
        public MembershipType()
        {
            Customers = new HashSet<Customer>();
        }
        [Key]
        public byte Id { get; set; }
        public string name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
        public virtual ICollection<Customer>Customers { get; set; }


    }
}