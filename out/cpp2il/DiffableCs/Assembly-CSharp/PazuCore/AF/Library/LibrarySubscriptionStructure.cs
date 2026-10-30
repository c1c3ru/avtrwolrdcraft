namespace PazuCore.AF.Library;

public class LibrarySubscriptionStructure : LibraryStructureBase
{
	internal class Featured
	{
		internal class Texts
		{
			public string subCtaTextKey; //Field offset: 0x10
			public string subTitle1TextKey; //Field offset: 0x18
			public string subTitle2TextKey; //Field offset: 0x20
			public string subIncludedTextKey; //Field offset: 0x28
			public string subMembershipTextKey; //Field offset: 0x30
			public string subBadgeTitleTextKey; //Field offset: 0x38
			public string subGamesTitleTextKey; //Field offset: 0x40
			public string subWidgetTextTextKey; //Field offset: 0x48
			public string subBadgeNumberTextKey; //Field offset: 0x50
			public string subDevicesUptoTextKey; //Field offset: 0x58
			public string subGamesNumberTextKey; //Field offset: 0x60
			public string subContentTitleTextKey; //Field offset: 0x68
			public string subDevicesTitleTextKey; //Field offset: 0x70
			public string subCtaBadgeDaysTextKey; //Field offset: 0x78
			public string subCtaBadgeTextTextKey; //Field offset: 0x80
			public string subCtaPostTrialTextKey; //Field offset: 0x88
			public string subDevicesNumberTextKey; //Field offset: 0x90
			public string subCtaAlternativeTextKey; //Field offset: 0x98
			public string subPricingTitle1TextKey; //Field offset: 0xA0
			public string subPricingTitle2TextKey; //Field offset: 0xA8
			public string subContentSubtitleTextKey; //Field offset: 0xB0
			public string subTrialDisclaimerTextKey; //Field offset: 0xB8
			public string subWidgetTextPostTrialTextKey; //Field offset: 0xC0
			public string subPricingTitle1PostTrialTextKey; //Field offset: 0xC8
			public string subPricingTitle2PostTrialTextKey; //Field offset: 0xD0

			public Texts() { }

		}

		public string coverPhotoUrl; //Field offset: 0x10
		public string videoUrl; //Field offset: 0x18
		public Texts texts; //Field offset: 0x20

		public Featured() { }

	}

	internal class GameBundleWindow
	{
		public string buttonTextKey; //Field offset: 0x10

		public GameBundleWindow() { }

	}

	internal class GameWindow
	{
		public string buttonTextKey; //Field offset: 0x10

		public GameWindow() { }

	}

	public Featured featured; //Field offset: 0x28
	public GameWindow gameWindow; //Field offset: 0x30
	public GameBundleWindow gameBundleWindow; //Field offset: 0x38

	public LibrarySubscriptionStructure() { }

}

