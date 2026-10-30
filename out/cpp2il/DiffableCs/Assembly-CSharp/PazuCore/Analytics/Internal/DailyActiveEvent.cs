namespace PazuCore.Analytics.Internal;

public class DailyActiveEvent : EventDataBase
{
	public long localTimestamp; //Field offset: 0x38

	public DailyActiveEvent() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

