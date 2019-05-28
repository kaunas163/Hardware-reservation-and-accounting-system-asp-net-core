using System.Collections.Generic;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.ViewsModels.Home
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Notifications = new List<Notification>();
            Reservations = new List<Reservation>();
            Events = new List<Event>();
        }

        public List<Notification> Notifications { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Event> Events { get; set; }
    }
}