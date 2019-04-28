namespace HardwareReservationAndAccountingSystem.Models
{
    public class EquipmentsInBundles
    {
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public int EquipmentBundleId { get; set; }
        public EquipmentBundle EquipmentBundle { get; set; }
    }
}