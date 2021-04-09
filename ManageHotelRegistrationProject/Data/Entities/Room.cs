using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Room : BaseEnity
    {
        public int Capacity { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; }
        public double PriceForAdults { get; set; }
        public double PriceForKids { get; set; }
        public int Number { get; set; }
        
    // public int ReservationId { get; set; }
      // public virtual  ICollection<Reservation> Reservations { get; set; }
    }
}
