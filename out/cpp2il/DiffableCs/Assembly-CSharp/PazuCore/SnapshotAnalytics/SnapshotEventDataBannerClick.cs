namespace PazuCore.SnapshotAnalytics;

public class SnapshotEventDataBannerClick : SnapshotEventData
{
	public int targetGameId; //Field offset: 0x3C
	public int position; //Field offset: 0x40
	public bool isInstalled; //Field offset: 0x44

	public SnapshotEventDataBannerClick() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

