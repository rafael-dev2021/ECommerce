namespace Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class BatteryObjectValue
{
    public string BatteryType { get; private set; } = string.Empty;
    public int BatteryCapacityMAh { get; private  set; }
    public bool IsBatteryRemovable { get; private  set; }
    
    public void SetBatteryType(string batteryType) => BatteryType = batteryType;
    public void SetBatteryCapacityMAh(int batteryCapacityMAh) => BatteryCapacityMAh = batteryCapacityMAh;
    public void SetIsBatteryRemovable(bool isBatteryRemovable) => IsBatteryRemovable = isBatteryRemovable;
}