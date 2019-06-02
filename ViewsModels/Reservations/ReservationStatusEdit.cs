using HardwareReservationAndAccountingSystem.Enums;
using HardwareReservationAndAccountingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareReservationAndAccountingSystem.ViewsModels.Reservations
{
    public class ReservationStatusEdit
    {
        public ReservationStatus ReservationStatus { get; set; }

        public Reservation Reservation { get; set; }
    }
}
