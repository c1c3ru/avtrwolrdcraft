namespace PazuCore.Analytics.Internal.ChangeTracking;

public class DeviceInfo
{
	public string system; //Field offset: 0x10
	public string language; //Field offset: 0x18
	public string country; //Field offset: 0x20
	public string timezone; //Field offset: 0x28

	public DeviceInfo() { }

	public static DeviceInfo CreateSynced() { }

	public bool IsSynced() { }

}

