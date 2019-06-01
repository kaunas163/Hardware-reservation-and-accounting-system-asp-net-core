using HardwareReservationAndAccountingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareReservationAndAccountingSystem.ViewsModels.Equipments
{
    public class EquipmentNewOrEdit
    {
        public Equipment Equipment { get; set; }

        public List<EquipmentType> EquipmentTypes { get; set; }
    }
}
