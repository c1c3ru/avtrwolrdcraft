namespace PazuCore.Analytics.Internal;

public class EventDataAlive : EventDataBase
{
	public int targetGameId; //Field offset: 0x38
	public long targetTimestamp; //Field offset: 0x40

	public EventDataAlive() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

