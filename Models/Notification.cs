using System;
using System.ComponentModel.DataAnnotations;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pavadinimas")]
        public string Title { get; set; }

        [Display(Name = "Aprašymas")]
        public string Description { get; set; }

        [Display(Name = "Sukūrimo data")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Ar perskaitytas?")]
        public bool IsRead { get; set; }

        [Display(Name = "Perskaitymo data")]
        public DateTime? ReadOn { get; set; }

        [Display(Name = "Ar archyvuotas?")]
        public bool IsArchived { get; set; }
    }
}