using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Client : BaseEnity
    {
        public Client()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsAdult { get; set; }
       // public int ReservationId { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
