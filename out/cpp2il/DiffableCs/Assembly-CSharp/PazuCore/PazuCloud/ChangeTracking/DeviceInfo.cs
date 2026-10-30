namespace PazuCore.PazuCloud.ChangeTracking;

public class DeviceInfo
{
	public string system; //Field offset: 0x10
	public string language; //Field offset: 0x18
	public string country; //Field offset: 0x20
	public string timezone; //Field offset: 0x28
	public string deviceName; //Field offset: 0x30
	public string identifierForVendor; //Field offset: 0x38

	public DeviceInfo() { }

	public string CreateHash() { }

	public static DeviceInfo CreateSynced() { }

}

