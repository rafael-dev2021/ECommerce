namespace Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class StorageObjectValue
{
    public int StorageGb { get; private set; }
    public int RamGb { get; private set; }
    
    public void SetStorageGb(int storageGb) => StorageGb = storageGb;
    public void SetRamGb(int ramGb) => RamGb = ramGb;
}