using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;

namespace UniDeviceInfo {
    public class EditorInfo : DeviceInfoBase {

        public string GetOS(){
            return SystemInfo.operatingSystem;
        }

        public string GetOSVersion(){
            return SystemInfo.operatingSystem;
        }

        public string GetVersion(){
            return "0";
        }

        public string GetBuildVersion(){
            return "0";
        }

        public string GetDeviceName(){
            return SystemInfo.deviceName;
        }

        public string GetDeviceModel(){
            return SystemInfo.deviceModel;
        }

        public string GetDeviceIdentifier(){
            return SystemInfo.deviceUniqueIdentifier;
        }

        public bool GetIfRooted(){
            return false;
        }
    }
}
#endif