namespace PazuCore.AF.Library;

public class LibraryGame
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public int contentId; //Field offset: 0x10

		public <>c__DisplayClass28_0() { }

		internal bool <GetConent>b__0(Content c) { }

	}

	internal enum AppearanceType
	{
		Regular = 0,
		Round = 1,
		Numbered = 2,
		RegularBig = 3,
		RoundBig = 4,
		NumberedBig = 5,
		CoverPhoto = 6,
		CoverPhotoBig = 7,
	}

	internal class Content
	{
		public int id; //Field offset: 0x10
		public string coverPhotoUrl; //Field offset: 0x18
		public string roundUrl; //Field offset: 0x20
		public string regularUrl; //Field offset: 0x28
		public AppContentData appContentData; //Field offset: 0x30

		public Content() { }

	}

	internal static class IdStart
	{
		public const int TYPE_RANGE = 1000000; //Field offset: 0x0
		public const int GAME = 0; //Field offset: 0x0
		public const int GAME_BUNDLE = 1000000; //Field offset: 0x0

	}

	internal class Platforms
	{
		internal class AppGalleryInfo : StoreInfo
		{

			public AppGalleryInfo() { }

		}

		internal class IOSInfo : StoreInfo
		{
			public string urlScheme; //Field offset: 0x30
			public string itunesLink; //Field offset: 0x38

			public IOSInfo() { }

		}

		internal class StoreInfo
		{
			public string bundleId; //Field offset: 0x10
			public bool isComingSoon; //Field offset: 0x18
			public string storeUrl; //Field offset: 0x20
			public string storeId; //Field offset: 0x28

			public StoreInfo() { }

		}

		public IOSInfo ios; //Field offset: 0x10
		public StoreInfo googlePlay; //Field offset: 0x18
		public StoreInfo amazon; //Field offset: 0x20
		public AppGalleryInfo appGallery; //Field offset: 0x28

		public Platforms() { }

	}

	public int id; //Field offset: 0x10
	public string displayNameKey; //Field offset: 0x18
	public string coverPhotoUrl; //Field offset: 0x20
	public string roundUrl; //Field offset: 0x28
	public string regularUrl; //Field offset: 0x30
	public string iconUrl; //Field offset: 0x38
	public string videoUrl; //Field offset: 0x40
	public List<Int32> skills; //Field offset: 0x48
	public bool isEditorChoice; //Field offset: 0x50
	public bool isNew; //Field offset: 0x51
	public string description; //Field offset: 0x58
	public List<Content> content; //Field offset: 0x60
	public List<Int32> games; //Field offset: 0x68
	public Platforms platforms; //Field offset: 0x70

	public LibraryGame() { }

	[CompilerGenerated]
	private bool <OpenBundleAppStore>g__ShowWebAppstore|25_0() { }

	public string GetBundleId() { }

	public Content GetConent(int contentId) { }

	public string GetContentScrollItemTextureUrl(AppearanceType appearanceType, Content content) { }

	public string GetScrollItemTextureUrl(AppearanceType appearanceType) { }

	public int GetStoreID() { }

	private StoreInfo GetStoreInfo() { }

	public string GetStoreUrl() { }

	public bool IsComingSoon() { }

	public static bool IsGameBundle(int gameId) { }

	public bool IsGameBundle() { }

	public bool OpenBundleAppStore() { }

}

