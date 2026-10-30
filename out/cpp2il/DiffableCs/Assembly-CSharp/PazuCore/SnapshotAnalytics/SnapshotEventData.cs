namespace PazuCore.SnapshotAnalytics;

public class SnapshotEventData : EventDataBase
{
	public SnapshotEventType snapshotEventType; //Field offset: 0x38

	public SnapshotEventData() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

