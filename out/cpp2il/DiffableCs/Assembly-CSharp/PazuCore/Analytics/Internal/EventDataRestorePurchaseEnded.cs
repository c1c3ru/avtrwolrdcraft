namespace PazuCore.Analytics.Internal;

public class EventDataRestorePurchaseEnded : EventDataBase
{
	public bool isFullVersion; //Field offset: 0x38
	public bool isSubscriptionActive; //Field offset: 0x39
	public string receipt; //Field offset: 0x40
	public string result; //Field offset: 0x48

	public EventDataRestorePurchaseEnded() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

