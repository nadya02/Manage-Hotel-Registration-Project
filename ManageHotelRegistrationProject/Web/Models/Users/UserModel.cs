using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Users
{
    public class UserModel
    {
        public int UserId { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "First name cannot be longer than 30 characters and should be minimum 3")]
        [Required]
        public string FirstName { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Middle name cannot be longer than 30 characters and should be minimum 3")]
        [Required]
        public string MiddleName { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Surname cannot be longer than 30 characters and should be minimum 3")]
        [Required]
        public string Surname { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "EGN cannot be less than 10 digits")]
        [Required]

        public string EGN { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Username cannot be longer than 30 characters")]
        public string Username { get; set; }
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime DateOfEmployment { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime DateOfDismissal { get; set; }
       // public bool IsAdmin { get; set; }
        public string Role { get; set; }

        public bool IsAdmin { get; set; }
        public IEnumerable<UserModel> GetUsers()
        {
            return new List<UserModel>()
            {
                new UserModel
                {
                        UserId = 1,
                        Username = "nadya",
                        FirstName = "Nadya",
                        MiddleName = "Petrova",
                        Surname = "Koleva",
                        Email = "nadiapk02@abv.bg",
                        EGN = "1111111111",
                        PhoneNumber = "0877777777",
                        Password = "nadya",
                        IsActive = true,
                        DateOfEmployment = DateTime.Parse("01/01/2001"),
                        IsAdmin = true
                }
            };
        }
    }

}
