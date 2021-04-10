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
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }    
        public string EGN { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public bool IsActive { get; set; }     
        public DateTime DateOfDismissal { get; set; }
        public bool IsAdmin { get; set; }
       /* public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }*/
    }

}
