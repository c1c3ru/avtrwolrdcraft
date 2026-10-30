namespace PazuCore.AF.ActionBar.Analytics;

public class HubEventDataBannerClick : HubEventData
{
	public int targetGameId; //Field offset: 0x3C
	public int position; //Field offset: 0x40
	public bool isInstalled; //Field offset: 0x44

	public HubEventDataBannerClick() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

