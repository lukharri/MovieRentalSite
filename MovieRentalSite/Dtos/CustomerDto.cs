using MovieRentalSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalSite.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        // exclude b/c this is a domain class and the property is creating dependency between 
        // the DTO and the domain model
        // changing membershipType will impact the DTO
        // public MembershipType MembershipType { get; set; }

        // Implicitly required b/c of byte type - data validation error will show up
        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

    }
}