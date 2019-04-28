using System.ComponentModel.DataAnnotations;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class EquipmentType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pavadinimas")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Display(Name = "Ar įrangos tipas archyvuotas?")]
        public bool IsArchived { get; set; }
    }
}