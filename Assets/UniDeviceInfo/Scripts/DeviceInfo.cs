using UnityEngine;
using System.Collections;

namespace UniDeviceInfo{
    public static class DeviceInfo {

        private static DeviceInfoBase _deviceInfo;
        private static DeviceInfoBase deviceInfo {
            get {
                if (_deviceInfo == null) {
                    #if UNITY_EDITOR
                    _deviceInfo = new EditorInfo();
                    #elif UNITY_IOS
                    _deviceInfo = new IOSDeviceInfo();
                    #elif UNITY_ANDROID
                    _deviceInfo = new AndroidDeviceInfo();
                    #endif
                }
                return _deviceInfo;
            }
        }

        private static string _os;
        public static string os {
            get {
                _os = _os ?? deviceInfo.GetOS ();
                return _os;
            }
        }

        private static string _osVersion;
        public static string osVersion {
            get {
                _osVersion = _osVersion ?? deviceInfo.GetOSVersion ();
                return _osVersion;
            }
        }

        private static string _version;
        public static string version {
            get {
                _version = _version ?? deviceInfo.GetVersion ();
                return _version;
            }
        }

        private static string _buildVersion;
        public static string buldVersion {
            get {
                _buildVersion = _buildVersion ?? deviceInfo.GetBuildVersion ();
                return _buildVersion;
            }
        }

        private static string _deviceName;
        public static string deviceName{
            get {
                _deviceName = _deviceName ?? deviceInfo.GetDeviceName ();
                return _deviceName;
            }
        }

        private static string _deviceModel;
        public static string deviceModel {
            get {
                _deviceModel = _deviceModel ?? deviceInfo.GetDeviceModel ();
                return _deviceModel;
            }
        }

        private static string _deviceId;
        public static string deviceId {
            get {
                _deviceId = _deviceId ?? deviceInfo.GetDeviceIdentifier ();
                return _deviceId;
            }
        }

        private static bool? _rooted;
        public static bool rooted {
            get {
                _rooted = _rooted ?? deviceInfo.GetIfRooted ();
                return (bool)_rooted;
            }
        }
    }
}
