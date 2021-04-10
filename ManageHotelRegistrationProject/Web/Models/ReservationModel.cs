using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ReservationModel
    {
        [Required]
        public virtual int? roomNumber { get; set; }

        [Required]
        public DateTime dateStart { get; set; }

        public DateTime dateEnd { get; set; }
        public bool breakfast { get; set; }
        public bool allInclusive { get; set; }

        public double cost { get; set; }

        public int clientsCnt { get; set; }
        public ClientModel[] clients { get; set; }
    }
}
