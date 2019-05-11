using System.ComponentModel.DataAnnotations;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class Picture
    {
        public int Id { get; set; }

        [Display(Name = "Sumažinta nuotrauka")]
        public string ThumbnailUrl { get; set; }

        [Display(Name = "Pilno dydžio nuotrauka")]
        public string FullSizeUrl { get; set; }

        [Display(Name = "Pagalbinis tekstas")]
        public string Caption { get; set; }

        [Display(Name = "Alternatyvus tekstas")]
        public string AlternativeText { get; set; }

        [Display(Name = "Priklauso įrangai")]
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}