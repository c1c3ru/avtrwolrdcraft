namespace PazuCore.Analytics.Internal;

public class EventDataParentalGateBase : EventDataBase
{
	public ParentalGateType gateType; //Field offset: 0x38
	public string pgContext; //Field offset: 0x40

	public EventDataParentalGateBase() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

