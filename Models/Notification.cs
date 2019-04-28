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

        [Display(Name = "Rezervacija")]
        public int? ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        [Display(Name = "Renginys")]
        public int? EventId { get; set; }
        public Event Event { get; set; }

        [Display(Name = "Įrangos vienetas")]
        public int? EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        [Display(Name = "Įrangos komplektas")]
        public int? EquipmentBundleId { get; set; }
        public EquipmentBundle EquipmentBundle { get; set; }
    }
}