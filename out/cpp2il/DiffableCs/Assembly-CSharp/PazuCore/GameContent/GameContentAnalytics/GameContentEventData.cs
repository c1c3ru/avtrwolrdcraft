namespace PazuCore.GameContent.GameContentAnalytics;

public class GameContentEventData : EventDataBase
{
	public GameContentEventType gameContentEventType; //Field offset: 0x38
	public int contentId; //Field offset: 0x3C
	public int position; //Field offset: 0x40

	public GameContentEventData() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

