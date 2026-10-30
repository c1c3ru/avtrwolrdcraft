namespace PazuCore.Analytics.Internal;

public class EventDataGameEvent : EventDataBase
{
	public String[] items; //Field offset: 0x38

	public EventDataGameEvent() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

