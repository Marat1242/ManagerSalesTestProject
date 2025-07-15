namespace ManagerSalesTestProject.Models;
public class EquipmentModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EquipmentType Type { get; set; }
    public EquipmentStatus Status { get; set; }
    public EquipmentModel(int id, string name, EquipmentType type, EquipmentStatus status)
    {
        Id = id;
        Name = name;
        Type = type;
        Status = status;
    }
    //пустой конструктор для EF Core
    public EquipmentModel() { }
};

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
    InRepair
}