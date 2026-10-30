namespace PazuCore.Analytics.Internal;

public class EventDataDownloadBase : EventDataBase
{
	public int newBuildNumber; //Field offset: 0x38
	public int newPazucoreVersion; //Field offset: 0x3C

	public EventDataDownloadBase() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

