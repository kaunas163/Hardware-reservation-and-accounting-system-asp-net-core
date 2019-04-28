using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class NotificationType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pavadinimas")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Display(Name = "Ar pranešimo tipas archyvuotas?")]
        public bool IsArchived { get; set; }

        [Display(Name = "Pranešimai")]
        public List<Notification> Notifications { get; set; }
    }
}