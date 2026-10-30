namespace PazuCore.AF.ActionBar.Analytics;

public static class HubEventDataFactory
{

	public static void CreateBannerClick(int targetGameId, int position, bool isInstalled) { }

	public static void CreateButtonClick(string buttonName) { }

	public static void CreateFeedBannerClick(string subCategory, int contentId, long publishTimestamp) { }

	public static void CreateMyGamesBannerClick(int currentGameId, int targetGameId, int position, bool isInstalled) { }

	public static void CreateMyGamesSuggestedGameClick(int currentGameId, int targetGameId, int position) { }

}

