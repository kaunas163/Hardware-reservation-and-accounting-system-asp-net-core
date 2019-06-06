using System.Collections.Generic;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.ViewsModels.Home
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Notifications = new List<Notification>();
            ReservationsNewest = new List<Reservation>();
            ReservationsToday = new List<Reservation>();
            ReservationsWeek = new List<Reservation>();
            ReservationsOld = new List<Reservation>();
            Events = new List<Event>();
            EquipmentBundles = new List<EquipmentBundle>();
        }

        public List<Notification> Notifications { get; set; }

        public List<Reservation> ReservationsNewest { get; set; }

        public List<Reservation> ReservationsToday { get; set; }

        public List<Reservation> ReservationsWeek { get; set; }

        public List<Reservation> ReservationsOld { get; set; }

        public List<Event> Events { get; set; }

        public List<EquipmentBundle> EquipmentBundles { get; set; }
    }
}