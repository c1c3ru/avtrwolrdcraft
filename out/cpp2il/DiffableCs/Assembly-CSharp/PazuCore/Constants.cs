namespace PazuCore;

public static class Constants
{
	internal static class AspectRatios
	{
		public const float VERY_TALL_SCREEN = 0,5; //Field offset: 0x0
		public const float TALL_SCREEN = 0,625; //Field offset: 0x0
		public const float VERY_WIDE_SCREEN = 2; //Field offset: 0x0
		public const float WIDE_SCREEN = 1,6; //Field offset: 0x0

	}

	internal static class DefaultIOSProductNames
	{
		public const string FULLVERSION = "fullversion"; //Field offset: 0x0
		public const string BLACKFRIDAY = "blackfriday"; //Field offset: 0x0
		public const string MEMBERSHIP_PREFIX = "membership"; //Field offset: 0x0
		public const string MEMBERSHIP_1 = "membership.1"; //Field offset: 0x0
		public const string MEMBERSHIP_1_B = "membership.1.b"; //Field offset: 0x0
		public const string MEMBERSHIP_2 = "membership.2"; //Field offset: 0x0
		public const string MEMBERSHIP_3 = "membership.3"; //Field offset: 0x0
		public const string MEMBERSHIP_4 = "membership.4"; //Field offset: 0x0
		public const string MEMBERSHIP_4_B = "membership.4.b"; //Field offset: 0x0

	}

	internal static class PlayerPrefsKeys
	{
		internal static class PazuCloud
		{
			public const string DID_CHECK_FOR_GAME_DATA = "pazucore_pazucloud_did_check_for_game_data"; //Field offset: 0x0
			public const string SHOULD_GET_NOT_CONSUMED = "pazucore_pazucloud_should_get_not_consumed"; //Field offset: 0x0
			public const string SHOULD_GET_GAME_DATA = "pazucore_pazucloud_should_get_game_data"; //Field offset: 0x0
			public const string SHOULD_SEND_GAME_DATA = "pazucore_pazucloud_should_send_game_data"; //Field offset: 0x0

		}

		public const string HIDE_RATE_US_FOREVER = "pazucore_hide_rate_us_forever"; //Field offset: 0x0
		public const string APP_LAUNCH = "pazucore_app_launch"; //Field offset: 0x0
		public const string APP_LAUNCH_SHOWED_PAYWALL = "pazucore_app_launch_showed_paywall"; //Field offset: 0x0
		public const string APP_SENT_ATTRIBUTION_TOKEN = "pazucore_app_sent_attribution_token"; //Field offset: 0x0
		public const string FINISH_GAME = "pazucore_finish_game"; //Field offset: 0x0
		public const string COUNTRY = "pazucore_country"; //Field offset: 0x0
		public const string LANGUAGE = "pazucore_language"; //Field offset: 0x0
		public const string PURCHASED_NON_CONSUMABLE_PRODUCTS = "pazucore_purchased_non_consumable_products"; //Field offset: 0x0
		public const string CALLED_ON_INITIALIZED_WITH_PAZU_UNITY_PURCHASER = "pazucore_called_OnInitialized_with_PazuUnityPurchaser"; //Field offset: 0x0
		public const string WEBVIEW_LAST_MODIFIED = "pazucore_webview_last_modified"; //Field offset: 0x0
		public const string CHECKED_ANDROID_INSTALL_REFERRER = "checked_android_install_referrer"; //Field offset: 0x0
		public const string PENDING_DEEP_LINK = "pazucore_pending_deep_link"; //Field offset: 0x0

	}

	internal static class Resources
	{
		public const string ROOT = "PazuCore"; //Field offset: 0x0
		public const string LOCALIZATION = "Localization"; //Field offset: 0x0
		public const string TEXT = "Text"; //Field offset: 0x0
		public const string ACTION_BAR = "PazuCore/AF/ActionBar"; //Field offset: 0x0
		public const string MY_GAMES = "PazuCore/AF/MyGames"; //Field offset: 0x0
		public const string LIBRARY = "PazuCore/AF/Library"; //Field offset: 0x0
		public const string CREATIVE = "PazuCore/Creative"; //Field offset: 0x0
		public const string PREFABS = "PazuCore/Prefabs"; //Field offset: 0x0
		public const string FOR_PARENTS = "PazuCore/ForParents"; //Field offset: 0x0
		public const string SOFT_PAYWALL = "PazuCore/SoftPaywall"; //Field offset: 0x0
		public const string PARENTAL_GATE_PORTRAIT = "PazuCore/Windows/ParentalGateDate_Portrait"; //Field offset: 0x0
		public const string PARENTAL_GATE_LANDSCAPE = "PazuCore/Windows/ParentalGateDate_Landscape"; //Field offset: 0x0
		public const string ENDSESSION = "PazuCore/EndSession"; //Field offset: 0x0

	}

	internal static class ScenesNames
	{
		public const string Start = "Start"; //Field offset: 0x0
		public const string CompanySplash = "CompanySplash"; //Field offset: 0x0
		public const string ShortCompanySplash = "ShortCompanySplash"; //Field offset: 0x0
		public const string Home = "Home"; //Field offset: 0x0
		public const string Languages = "Languages"; //Field offset: 0x0
		public const string Library = "Library"; //Field offset: 0x0
		public const string MyGames = "MyGames"; //Field offset: 0x0
		public const string Feed = "Feed"; //Field offset: 0x0
		public const string ForParents = "ForParents"; //Field offset: 0x0
		public const string SoftPaywall = "SoftPaywall"; //Field offset: 0x0
		public const string PostPurchase = "PostPurchase"; //Field offset: 0x0
		public const string FTUE = "FTUE"; //Field offset: 0x0
		public const string GDPR = "GDPR"; //Field offset: 0x0

	}

	internal static class StoreSpecific
	{
		public const string HUAWEI_PACKAGE_NANE_ADD = ".huawei"; //Field offset: 0x0

	}

	internal static class WindowsNames
	{
		public const string BlackFriday = "BlackFriday"; //Field offset: 0x0
		public const string SignIn = "SignIn"; //Field offset: 0x0
		public const string PrivacyPolicy = "PrivacyPolicy"; //Field offset: 0x0
		public const string TermsOfUse = "TermsOfUse"; //Field offset: 0x0
		public const string Message = "Message"; //Field offset: 0x0
		public const string SignUp = "SignUp"; //Field offset: 0x0
		public const string ForgotPassword = "ForgotPassword"; //Field offset: 0x0
		public const string ConnectDevices = "ConnectDevices"; //Field offset: 0x0
		public const string Feedback = "Feedback"; //Field offset: 0x0
		public const string ContactUs = "ContactUs"; //Field offset: 0x0
		public const string ManageDevices = "ManageDevices"; //Field offset: 0x0

	}

	public const string RECEIPT_NO_DATA = "NO_DATA"; //Field offset: 0x0
	public const int EXCLUDE_SOUND_CHANNEL = 2147483647; //Field offset: 0x0

}

