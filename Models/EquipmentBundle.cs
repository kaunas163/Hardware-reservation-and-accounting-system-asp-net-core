using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class EquipmentBundle
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pavadinimas")]
        public string Title { get; set; }

        [Display(Name = "Aprašymas")]
        public string Description { get; set; }

        [Display(Name = "Sukūrimo laikas")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Atnaujinimo laikas")]
        public DateTime UpdatedOn { get; set; }

        public List<EquipmentsInBundles> EquipmentsInBundles { get; set; }

        [Display(Name = "Rezervacijos")]
        public List<Reservation> Reservations { get; set; }

        [Display(Name = "Pranešimai")]
        public List<Notification> Notifications { get; set; }
    }
}