namespace PazuCore.Analytics.Internal;

public class EventDataPurchaseBase : EventDataBase
{
	public string productId; //Field offset: 0x38
	public string priceDisplay; //Field offset: 0x40
	public string currency; //Field offset: 0x48
	public string priceValue; //Field offset: 0x50

	public EventDataPurchaseBase() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

