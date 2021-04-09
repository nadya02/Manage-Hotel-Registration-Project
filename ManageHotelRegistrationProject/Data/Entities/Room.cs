using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class Room : BaseEnity
    {
        [Range(1, 7)] //може да има минимум 1 човек в една стая и максимум 7 души
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public double PriceForAdults { get; set; }
        [Required]
        public double PriceForKids { get; set; }
        [Required]
        public int Number { get; set; }
        
    // public int ReservationId { get; set; }
      // public virtual  ICollection<Reservation> Reservations { get; set; }
    }
}
