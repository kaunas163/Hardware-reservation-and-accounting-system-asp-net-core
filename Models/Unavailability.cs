using System;
using System.ComponentModel.DataAnnotations;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class Unavailability
    {
        public int Id { get; set; }

        [Display(Name = "Pradžios laikas")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Pabaigos laikas")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Ar taikoma viskam?")]
        public bool IsForEverything { get; set; }

        [Display(Name = "Įranga")]
        public int? EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        [Display(Name = "Įrangos komplektas")]
        public int? EquipmentBundleId { get; set; }
        public EquipmentBundle EquipmentBundle { get; set; }
    }
}