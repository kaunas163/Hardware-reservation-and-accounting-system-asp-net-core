using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HardwareReservationAndAccountingSystem.Enums;

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

        [Display(Name = "Sukūrimo laikas")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Atnaujinimo laikas")]
        public DateTime UpdatedOn { get; set; }

        [Display(Name = "Būsena")]
        public EquipmentStatus Status { get; set; }

        [Display(Name = "Įrangos tipas")]
        public int EquipmentTypeId { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public List<EquipmentsInBundles> EquipmentsInBundles { get; set; }

        [Display(Name = "Pranešimai")]
        public List<Notification> Notifications { get; set; }

        [Display(Name = "Pradinis įrangos įrašas")]
        public int? OriginalEquipmentId { get; set; }
        public Equipment OriginalEquipment { get; set; }

        [Display(Name = "Nerezervuojami laikai")]
        public List<Unavailability> Unavailabilities { get; set; }

        [Display(Name = "Nuotraukos")]
        public List<Picture> Pictures { get; set; }
    }
}