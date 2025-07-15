namespace ManagerSalesTestProject.Models;
public class EquipmentModel
{
    public int id { get; set; }
    public string Name { get; set; }
    public EquipmentType equipmentType { get; set; }
    public EquipmentStatus equipmentStatus { get; set; }

}
public enum EquipmentType
{
    Printer,
    Scanner,
    Monitor
}
public enum EquipmentStatus
{
    InUsing,
    InWareHouse,
    InRapair
}