namespace UniDeviceInfo{
    public interface DeviceInfoBase {
        string GetOS();
        string GetOSVersion();
        string GetVersion();
        string GetBuildVersion();
        string GetDeviceName();
        string GetDeviceModel();
        string GetDeviceIdentifier();
        bool GetIfRooted();
    }
}
