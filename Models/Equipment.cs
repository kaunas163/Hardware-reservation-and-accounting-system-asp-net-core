using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pavadinimas")]
        public string Title { get; set; }

        [Display(Name = "Aprašymas")]
        public string Description { get; set; }

        [Display(Name = "Įrangos tipas")]
        public int EquipmentTypeId { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public List<EquipmentsInBundles> EquipmentsInBundles { get; set; }

        [Display(Name = "Pranešimai")]
        public List<Notification> Notifications { get; set; }
    }
}