namespace PazuCore.Analytics.Internal;

public class QueueItem
{
	public readonly string fileName; //Field offset: 0x10
	public readonly string dataString; //Field offset: 0x18

	public QueueItem(string fileName, string dataString) { }

	public Dictionary<String, Object> CreateObject() { }

}

