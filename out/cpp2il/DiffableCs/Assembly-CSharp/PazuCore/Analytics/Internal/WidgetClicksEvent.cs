namespace PazuCore.Analytics.Internal;

public class WidgetClicksEvent : EventDataBase
{
	public List<Object> widgetClicks; //Field offset: 0x38

	public WidgetClicksEvent() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

