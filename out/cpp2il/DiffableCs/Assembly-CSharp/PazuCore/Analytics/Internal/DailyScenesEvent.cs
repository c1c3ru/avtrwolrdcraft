namespace PazuCore.Analytics.Internal;

public class DailyScenesEvent : EventDataBase
{
	public List<Object> sceneNames; //Field offset: 0x38

	public DailyScenesEvent() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

