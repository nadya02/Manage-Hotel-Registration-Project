using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class User : IdentityUser<string>
    {
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string MiddleName { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Surname { get; set; }    
        [StringLength(10, MinimumLength = 10)]
        [Required]
        public string EGN { get; set; }
        [Required]
        public DateTime DateOfEmployment { get; set; }
        [Required]
        public bool IsActive { get; set; }     
        public DateTime DateOfDismissal { get; set; }
        public bool IsAdmin { get; set; }
       /* public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }*/
    }

}
