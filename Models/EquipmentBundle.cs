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

        [Display(Name = "Ar paskelbtas ir leidžiamas rezervuoti?")]
        public bool IsPublic { get; set; }

        public List<EquipmentsInBundles> EquipmentsInBundles { get; set; }
    }
}