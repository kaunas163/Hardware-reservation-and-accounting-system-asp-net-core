using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HardwareReservationAndAccountingSystem.Enums;

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

        [Display(Name = "Komentaras")]
        public string Comment { get; set; }

        [Display(Name = "Rezervacijos būsena")]
        public ReservationStatus Status { get; set; }

        [Display(Name = "Įrangos komplektas")]
        public int EquipmentBundleId { get; set; }
        public EquipmentBundle EquipmentBundle { get; set; }

        [Display(Name = "Pranešimai")]
        public List<Notification> Notifications { get; set; }

        [Required]
        [Display(Name = "Užsakovas")]
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }

        [Display(Name = "Renginys")]
        public int? EventId { get; set; }
        public Event Event { get; set; }

        [Display(Name = "Pradinis rezervacijos įrašas")]
        public int? OriginalReservationId { get; set; }
        public Reservation OriginalReservation { get; set; }
    }
}