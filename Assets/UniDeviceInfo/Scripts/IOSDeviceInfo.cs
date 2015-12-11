using UnityEngine;
using System.Runtime.InteropServices;

#if UNITY_IOS
namespace UniDeviceInfo{
    public class IOSDeviceInfo : DeviceInfoBase {

        [DllImport("__Internal")]
        private static extern string GetVersionName_();
        [DllImport("__Internal")]
        private static extern string GetBuildVersionName_ ();
        [DllImport("__Internal")]
        private static extern string GetModelName_();
        [DllImport("__Internal")]
        private static extern bool IsJailBreakBroken_();

        public string GetOS(){
            return SystemInfo.operatingSystem;
        }

        public string GetOSVersion(){
            var version = SystemInfo.operatingSystem.Split (' ');
            return version [version.Length - 1];
        }

        public string GetVersion(){
            return GetVersionName_ ();
        }

        public string GetBuildVersion(){
            return GetBuildVersionName_ ();
        }

        public string GetDeviceName(){
            return GetModelName_ ();
        }

        public string GetDeviceModel(){
            return SystemInfo.deviceModel;
        }

        public string GetDeviceIdentifier(){
            return SystemInfo.deviceUniqueIdentifier;
        }

        public bool GetIfRooted(){
            return IsJailBreakBroken_ ();
        }
    }
}
#endif