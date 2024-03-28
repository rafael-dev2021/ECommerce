namespace Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class CameraObjectValue
{
    public string MainCameraSpec { get; private set; } = string.Empty;
    public string MainCameraFeature { get; private set; } = string.Empty;
    public string SelfieCameraSpec { get; private set; } = string.Empty;
    public string SelfieCameraFeature { get; private set; } = string.Empty;
    
    public void SetMainCameraSpec(string mainCameraSpec) => MainCameraSpec = mainCameraSpec;
    public void SetMainCameraFeature(string mainCameraFeature) => MainCameraFeature = mainCameraFeature;
    public void SetSelfieCameraSpec(string selfieCameraSpec) => SelfieCameraSpec = selfieCameraSpec;
    public void SetSelfieCameraFeature(string selfieCameraFeature) => SelfieCameraFeature = selfieCameraFeature;
}