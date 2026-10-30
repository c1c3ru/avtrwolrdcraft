namespace PazuCore.Analytics.Internal;

public class EventDataPurchaseSucceeded : EventDataPurchaseBase
{
	public string receipt; //Field offset: 0x58

	public EventDataPurchaseSucceeded() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

