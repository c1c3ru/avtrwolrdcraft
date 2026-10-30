namespace PazuCore.AF.MyGames;

public class MyGamesSuggestionsData
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<LibraryGame, Int32> <>9__3_0; //Field offset: 0x8
		public static Func<String, Int32> <>9__3_1; //Field offset: 0x10
		public static Comparison<Int32> <>9__3_4; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal int <Parse>b__3_0(LibraryGame game) { }

		internal int <Parse>b__3_1(string key) { }

		internal int <Parse>b__3_4(int gameId1, int gameId2) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public List<Int32> libraryGamesIds; //Field offset: 0x10
		public Predicate<Int32> <>9__3; //Field offset: 0x18

		public <>c__DisplayClass3_0() { }

		internal bool <Parse>b__2(int gameId) { }

		internal bool <Parse>b__3(int id) { }

	}

	internal class GameInfo
	{
		public readonly string title; //Field offset: 0x10
		public readonly float rating; //Field offset: 0x18
		public readonly string iconUrl; //Field offset: 0x20

		public GameInfo(Dictionary<String, Object> dict) { }

	}

	public readonly Dictionary<Int32, List`1<Int32>> suggestions; //Field offset: 0x10
	public readonly Dictionary<Int32, GameInfo> gamesInfo; //Field offset: 0x18

	public MyGamesSuggestionsData() { }

	public static ValueTuple<MyGamesSuggestionsData, String> Parse(Dictionary<String, Object> jwtData, Dictionary<String, Object> baseData = null) { }

}

