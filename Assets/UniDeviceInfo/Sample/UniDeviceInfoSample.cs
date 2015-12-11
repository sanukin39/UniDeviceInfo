using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UniDeviceInfo;

public class UniDeviceInfoSample : MonoBehaviour {

    [SerializeField] private Text os;
    [SerializeField] private Text osVersion;
    [SerializeField] private Text version;
    [SerializeField] private Text buildVersion;
    [SerializeField] private Text deviceName;
    [SerializeField] private Text deviceModel;
    [SerializeField] private Text deviceId;
    [SerializeField] private Text rooted;

    void Start () {
        os.text = string.Format ("OS: {0}", DeviceInfo.os);
        osVersion.text = string.Format ("OS Version: {0}", DeviceInfo.osVersion);
        version.text = string.Format ("Version: {0}", DeviceInfo.version);
        buildVersion.text = string.Format ("BuildVersion: {0}", DeviceInfo.buldVersion);
        deviceId.text = string.Format ("DeviceIdentifier: {0}", DeviceInfo.deviceId);
        deviceName.text = string.Format ("DeviceName: {0}", DeviceInfo.deviceName);
        deviceModel.text = string.Format ("DeviceModel: {0}", DeviceInfo.deviceModel);
        rooted.text = string.Format ("Rooted: {0}", DeviceInfo.rooted);
    }

}
