namespace PazuCore.AF.Library;

public class LibraryData
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Int32, Boolean> <>9__25_3; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <BuildSections>b__25_3(int x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public int gameId; //Field offset: 0x10

		public <>c__DisplayClass22_0() { }

		internal bool <SyncCurrentGame>b__0(LibraryGame x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public HashSet<Int32> removedGameIds; //Field offset: 0x10
		public Predicate<Int32> <>9__5; //Field offset: 0x18

		public <>c__DisplayClass24_0() { }

		internal bool <RemoveGamesThatAreNotInThisPlatform>b__0(LibraryGame game) { }

		internal bool <RemoveGamesThatAreNotInThisPlatform>b__1(int x) { }

		internal bool <RemoveGamesThatAreNotInThisPlatform>b__2(int x) { }

		internal bool <RemoveGamesThatAreNotInThisPlatform>b__3(int x) { }

		internal bool <RemoveGamesThatAreNotInThisPlatform>b__4(int x) { }

		internal bool <RemoveGamesThatAreNotInThisPlatform>b__5(int x) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass25_0
	{
		public int featuredGameIndex; //Field offset: 0x0
		public Featured featured; //Field offset: 0x8
		public bool refreshOnly; //Field offset: 0x10
		public LibraryData <>4__this; //Field offset: 0x18

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_1
	{
		public Type sectionType; //Field offset: 0x10

		public <>c__DisplayClass25_1() { }

		internal bool <BuildSections>b__2(LibrarySection x) { }

	}

	internal class LocalizationText
	{
		public string key; //Field offset: 0x10
		public string value; //Field offset: 0x18

		public LocalizationText() { }

	}

	public const string FEATURED_GAME_CHANGED_TIME_KEY = "PazuCore_Library_LibraryData_FeaturedGameChangedTime"; //Field offset: 0x0
	public const string FEATURED_GAME_INDEX_KEY = "PazuCore_Library_LibraryData_FeaturedGameIndex"; //Field offset: 0x0
	public LibraryRegularStructure regularStructure; //Field offset: 0x10
	public List<LibraryGame> games; //Field offset: 0x18
	public List<LocalizationText> localizationTexts; //Field offset: 0x20
	public string languageCode; //Field offset: 0x28
	public string countryCode; //Field offset: 0x30
	public string dateModified; //Field offset: 0x38
	public int cmsVersion; //Field offset: 0x40
	public List<Int32> relatedGames; //Field offset: 0x48
	public List<Int32> top10Games; //Field offset: 0x50
	public List<Int32> top10GamesFallback; //Field offset: 0x58
	public string countryLocalizedName; //Field offset: 0x60
	private Dictionary<Int32, LibraryGame> _hashedGames; //Field offset: 0x68
	private Dictionary<String, String> _hashedLocalizationTexts; //Field offset: 0x70
	private Nullable<Int32> _featuredGameId; //Field offset: 0x78
	private long _lastFeaturedGameChangeTime; //Field offset: 0x80

	public LibraryData() { }

	[CompilerGenerated]
	internal static void <BuildSections>g__SetSectionsGamesForStructure|25_1(LibraryStructureBase libraryStructureBase, Type sectionType, List<Int32> gamesList) { }

	[CompilerGenerated]
	private void <BuildSections>g__SyncFeaturedGameIndex|25_0(ref <>c__DisplayClass25_0 unnamed_param_0) { }

	private void BuildSections(bool refreshOnly = false, bool ignoreTimers = false) { }

	public LibraryGame GetFeaturedGame() { }

	public long GetFeaturedGameRotationInterval() { }

	public LibraryGame GetGame(int gameId) { }

	public string GetLocalizationText(string key, string fallBackText = null) { }

	public LibraryStructureBase GetStructure(LibraryType libraryType) { }

	public void Init(bool ignoreTimers = false) { }

	public void RefreshSectionsIfNeeded() { }

	private void RemoveGamesThatAreNotInThisPlatform() { }

	private bool ShouldRecalculateFeaturedGame() { }

	public bool ShouldUseNativeAppstore() { }

	private void SyncCurrentGame() { }

}

