using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.ViewsModels.EquipmentBundles
{
    public class AddEquipmentToBundleForm
    {
        public EquipmentBundle EquipmentBundle { get; set; }

        public List<Equipment> Equipments { get; set; }
    }
}
