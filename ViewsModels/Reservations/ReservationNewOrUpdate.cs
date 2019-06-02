using HardwareReservationAndAccountingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareReservationAndAccountingSystem.ViewsModels.Reservations
{
    public class ReservationNewOrUpdate
    {
        public Reservation Reservation { get; set; }

        public List<EquipmentBundle> EquipmentBundles { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}
