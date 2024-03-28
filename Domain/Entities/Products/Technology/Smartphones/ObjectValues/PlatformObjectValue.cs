namespace Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class PlatformObjectValue
{
    public string OperatingSystem { get; private set; } = string.Empty;
    public string Chipset { get; private  set; } = string.Empty;
    public string Gpu { get; private  set; } = string.Empty;
    public string Cpu { get; private  set; } = string.Empty;
    
    public void SetOperatingSystem(string operatingSystem) => OperatingSystem = operatingSystem;
    public void SetChipset(string chipset) => Chipset = chipset;
    public void SetGpu(string gpu) => Gpu = gpu;
    public void SetCpu(string cpu) => Cpu = cpu;
}