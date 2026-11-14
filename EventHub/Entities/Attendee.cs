using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Entities
{
    public class Attendee
    {
         public int Id { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; } = default!;
        [Required, MaxLength(200)]
        public string Email { get; set; } = default!;
        [Required, MaxLength(150)]
        public string Street { get; set; } = default!;
        [Required, MaxLength(100)]
        public string City { get; set; } = default!;
        [Required, MaxLength(100)]
        public string Country { get; set; } = default!;
        [Required, MaxLength(20)]
        [Column("ZipCode")]
        public string PostalCode { get; set; } = default!;
        [NotMapped]
        public string FullAddress => $"{Street}, {City}, {Country}, {PostalCode}";
        public Badge? Badge { get; set; }  
    }
}
