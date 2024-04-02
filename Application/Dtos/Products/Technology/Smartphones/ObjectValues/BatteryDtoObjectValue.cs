namespace Application.Dtos.Products.Technology.Smartphones.ObjectValues;

public record BatteryDtoObjectValue(
    string BatteryType,
    int BatteryCapacityMAh,
    bool IsBatteryRemovable);