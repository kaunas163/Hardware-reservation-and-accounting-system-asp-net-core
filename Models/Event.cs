using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class Event
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Pavadinimas")]
        public string Title { get; set; }

        [Display(Name = "Lokacija")]
        public string Location { get; set; }

        [Display(Name = "Pradžia")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Pabaiga")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Komentaras")]
        public string Comment { get; set; }

        [Display(Name = "Pranešimai")]
        public List<Notification> Notifications { get; set; }

        [Display(Name = "Rezervacijos")]
        public List<Reservation> Reservations { get; set; }
    }
}