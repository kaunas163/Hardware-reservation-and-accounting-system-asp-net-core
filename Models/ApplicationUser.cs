using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Vardas")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Pavardė")]
        [MaxLength(50)]
        public string Surname { get; set; }
    }
}