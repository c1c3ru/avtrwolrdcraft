namespace PazuCore.GameUpdate.GameUpdateAnalytics;

public class GameUpdateEventData : EventDataBase
{
	public GameUpdateEventType gameUpdateEventType; //Field offset: 0x38

	public GameUpdateEventData() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

