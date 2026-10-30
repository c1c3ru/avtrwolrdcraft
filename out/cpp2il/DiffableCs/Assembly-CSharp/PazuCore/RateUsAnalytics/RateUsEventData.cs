namespace PazuCore.RateUsAnalytics;

public class RateUsEventData : EventDataBase
{
	public RateUsEventType rateUsEventType; //Field offset: 0x38
	public string extraData; //Field offset: 0x40

	public RateUsEventData() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

