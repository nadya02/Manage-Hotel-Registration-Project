using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ClientModel
    {
        public int id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "first name cannot be longer than 30 characters")]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public bool isAdult { get; set; }
    }
}
