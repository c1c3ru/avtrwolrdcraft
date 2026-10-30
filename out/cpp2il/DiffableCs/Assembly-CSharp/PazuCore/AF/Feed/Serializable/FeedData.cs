namespace PazuCore.AF.Feed.Serializable;

public class FeedData
{
	public readonly List<FeedItemData> items; //Field offset: 0x10
	public readonly long publishTimestamp; //Field offset: 0x18

	public FeedData() { }

	public FeedData(List<FeedItemData> items, long publishTimestamp) { }

}

