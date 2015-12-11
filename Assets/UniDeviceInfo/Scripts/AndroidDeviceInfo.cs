using UnityEngine;
using System.Collections;

#if UNITY_ANDROID
namespace UniDeviceInfo{
    public class AndroidDeviceInfo : DeviceInfoBase {

        public string GetOS(){
            return SystemInfo.operatingSystem;
        }

        public string GetOSVersion(){
            // version string example: Android OS 6.0.1 / API-23 (xxxxxxxxxxxx)
            var version = SystemInfo.operatingSystem.Split (' ');
            return version [2];
        }

        public string GetVersion(){
            return GetDeviceInfoClass().CallStatic<string>("getVersionName", GetContext());
        }

        public string GetBuildVersion(){
            return GetDeviceInfoClass().CallStatic<int> ("getVersionCode", GetContext()).ToString ();
        }

        public string GetDeviceName(){
            return SystemInfo.deviceModel;
        }

        public string GetDeviceModel(){
            return GetDeviceInfoClass().CallStatic<string> ("getModel");
        }

        public string GetDeviceIdentifier(){
            return SystemInfo.deviceUniqueIdentifier;
        }

        public bool GetIfRooted(){
            return GetDeviceInfoClass().CallStatic<bool> ("isRooted", GetContext());
        }

        private AndroidJavaObject GetDeviceInfoClass(){
            return new AndroidJavaObject("jp.ne.donuts.deviceinfo.DeviceInfo");
        }

        private AndroidJavaObject GetContext(){
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("getApplicationContext");
        }
    }
}
#endif