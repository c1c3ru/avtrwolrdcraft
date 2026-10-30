namespace PazuCore.Analytics.Internal;

public class EventDataUseTimeBase : EventDataBase
{
	public UseTimeEventType useTimeEventType; //Field offset: 0x38

	public EventDataUseTimeBase() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

