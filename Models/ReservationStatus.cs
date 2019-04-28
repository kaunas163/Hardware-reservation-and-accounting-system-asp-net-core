using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class ReservationStatus
    {
        public byte Id { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        [Display(Name = "Pavadinimas")]
        public string Title { get; set; }

        [Display(Name = "Aprašymas")]
        public string Description { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}