namespace PazuCore.Analytics.Internal;

public class EventDataSceneOpen : EventDataBase
{
	public SceneName scene; //Field offset: 0x38
	public string gameSceneName; //Field offset: 0x40

	public EventDataSceneOpen() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

