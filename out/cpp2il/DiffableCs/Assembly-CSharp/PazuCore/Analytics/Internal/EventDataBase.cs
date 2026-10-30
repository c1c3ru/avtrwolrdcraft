namespace PazuCore.Analytics.Internal;

public class EventDataBase
{
	public const int STRUCTURE_VERSION = 7; //Field offset: 0x0
	public int id; //Field offset: 0x10
	public int gameId; //Field offset: 0x14
	public int pazucoreVersion; //Field offset: 0x18
	public int buildNumber; //Field offset: 0x1C
	public EventType type; //Field offset: 0x20
	public long timestamp; //Field offset: 0x28
	public String[] context; //Field offset: 0x30

	public EventDataBase() { }

	public override Dictionary<String, Object> GetRequestObject() { }

	protected string GetStringFromBool(bool boolValue) { }

}

