namespace PazuCore.AF.ActionBar.Analytics;

public class HubEventData : EventDataBase
{
	public HubEventType hubEventType; //Field offset: 0x38

	public HubEventData() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

