using MovieRentalSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalSite.Dtos
{
    public class MovieDto
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime? DateReleased { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }

        //public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

    }
}