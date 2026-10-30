namespace PazuCore.Analytics.Internal;

public class EventDataUserInteraction : EventDataBase
{
	public String[] items; //Field offset: 0x38

	public EventDataUserInteraction() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

