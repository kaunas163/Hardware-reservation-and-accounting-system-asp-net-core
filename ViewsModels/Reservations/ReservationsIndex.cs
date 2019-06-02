using HardwareReservationAndAccountingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareReservationAndAccountingSystem.ViewsModels.Reservations
{
    public class ReservationsIndex
    {
        public List<Reservation> Reservations { get; set; }

        public List<EquipmentBundle> EquipmentBundles { get; set; }
    }
}
