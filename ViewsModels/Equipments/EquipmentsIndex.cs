using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.ViewsModels.Equipments
{
    public class EquipmentsIndex
    {
        public List<Equipment> Equipments { get; set; }

        public List<EquipmentType> EquipmentTypes { get; set; }
    }
}
