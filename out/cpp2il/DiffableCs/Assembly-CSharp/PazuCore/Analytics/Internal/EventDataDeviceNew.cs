namespace PazuCore.Analytics.Internal;

public class EventDataDeviceNew : EventDataBase
{
	public string model; //Field offset: 0x38
	public string system; //Field offset: 0x40
	public PlatformType platform; //Field offset: 0x48
	public string identifierForVendor; //Field offset: 0x50
	public bool isSimulator; //Field offset: 0x58
	public string language; //Field offset: 0x60
	public string country; //Field offset: 0x68
	public string timezone; //Field offset: 0x70

	public EventDataDeviceNew() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

