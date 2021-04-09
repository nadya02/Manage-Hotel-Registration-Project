using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Data.Entities
{
    public class Reservation : BaseEnity 
    {
        public Reservation()
        {
            this.Clients = new HashSet<Client>();
        }

        public virtual ICollection<Client> Clients { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        [DisplayName("Date of arrival: ")]
        public DateTime DateOfArrival { get; set; }

        [DisplayName("Date of leaving: ")]
        public DateTime DateOfLeaving { get; set; }
        public bool IsIncludedBreakfast { get; set; }
        public bool AllInclusive { get; set; }
        public double FinalPrice { get; set; }
    }
}
