namespace PazuCore.AF.Feed.Serializable;

public class FeedItemData
{
	internal class Assets
	{
		public readonly string roundPhotoUrl; //Field offset: 0x10
		public readonly string coverPhotoUrl; //Field offset: 0x18

		public Assets(string roundPhotoUrl, string coverPhotoUrl) { }

	}

	internal class CTAData
	{
		public readonly int gameId; //Field offset: 0x10
		public readonly int bundleId; //Field offset: 0x14
		public readonly string url; //Field offset: 0x18
		public readonly AppContentData appContentData; //Field offset: 0x20

		public CTAData(int gameId, int bundleId, string url, AppContentData appContentData) { }

	}

	public readonly int feedId; //Field offset: 0x10
	public readonly LayoutType layout; //Field offset: 0x14
	public readonly int CMSFeedId; //Field offset: 0x18
	public readonly string title; //Field offset: 0x20
	public readonly string description; //Field offset: 0x28
	public readonly long timestamp; //Field offset: 0x30
	public readonly Assets assets; //Field offset: 0x38
	public readonly CTAType ctaType; //Field offset: 0x40
	public readonly CTAData ctaData; //Field offset: 0x48
	public readonly FeedItemCTA feedItemCTA; //Field offset: 0x50

	public FeedItemData(int feedId, int layout, int CMSFeedId, string title, string description, long timestamp, string roundPhotoUrl, string coverPhotoUrl, string ctaType, int ctaGameId, int ctaBundleId, string ctaUrl, int ctaActionType, Int32[] ctaAppContent) { }

	public void SendAnalyticsEvent(string subCategory) { }

}

