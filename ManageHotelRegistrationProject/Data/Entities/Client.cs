using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class Client : BaseEnity
    {
        public Client()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Surname { get; set; }

       // [RegularExpression(@"[^0-9]", ErrorMessage = "Please enter propar contact data!")]
        [StringLength(10, MinimumLength = 10)]
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool IsAdult { get; set; }
       // public int ReservationId { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
