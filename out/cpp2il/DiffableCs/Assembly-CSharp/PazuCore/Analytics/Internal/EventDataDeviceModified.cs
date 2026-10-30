namespace PazuCore.Analytics.Internal;

public class EventDataDeviceModified : EventDataBase
{
	public string system; //Field offset: 0x38
	public string language; //Field offset: 0x40
	public string country; //Field offset: 0x48
	public string timezone; //Field offset: 0x50

	public EventDataDeviceModified() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

