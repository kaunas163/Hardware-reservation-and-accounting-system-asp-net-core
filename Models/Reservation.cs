using System;
using System.ComponentModel.DataAnnotations;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Display(Name = "Rezervacija nuo")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Rezervacija iki")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Sukūrimo laikas")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Atnaujinimo laikas")]
        public DateTime UpdatedOn { get; set; }
    }
}