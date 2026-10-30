//Type is in global namespace

internal static class LobbyPatcher
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Comparison<Int32> <>9__3_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <ApplyPatchesToLobby>b__3_0(int first, int second) { }

	}

	public class LobbyPatch
	{
		public string op; //Field offset: 0x10
		public string path; //Field offset: 0x18
		public object value; //Field offset: 0x20

		[Preserve]
		public LobbyPatch() { }

	}

	public class LobbyPatches
	{
		public int Version; //Field offset: 0x10
		public List<LobbyPatch> Patches; //Field offset: 0x18

		[Preserve]
		public LobbyPatches() { }

	}

	private const int MaxPlayerCount = 100; //Field offset: 0x0

	internal static void ApplyPatchesToLobby(ILobbyChanges changes, Lobby lobbyToChange) { }

	internal static LobbyPatcherChanges GetLobbyChanges(string json) { }

	internal static LobbyPatcherChanges GetLobbyDiff(Lobby lobby1, Lobby lobby2) { }

	internal static LobbyPatcherChanges GetLobbyPatches(LobbyPatches lobbyPatches) { }

	private static string GetPlayerPathAndIndex(LobbyPatch patch, out int playerIndex) { }

	private static bool IsLobbyDataEqual(DataObject d1, DataObject d2) { }

	private static bool IsPlayerDataEqual(PlayerDataObject d1, PlayerDataObject d2) { }

	private static void ParseAddLobbyData(JObject data, LobbyPatcherChanges changes) { }

	private static void ParseAddOrReplacePlayerData(int index, LobbyPatch patch, string path, LobbyPatcherChanges changes, bool isAdding = false) { }

	private static void ParseAddPatch(LobbyPatch patch, LobbyPatcherChanges changes) { }

	private static void ParseAddPlayer(LobbyPatch patch, int index, LobbyPatcherChanges changes) { }

	private static void ParseLobbyDataAddOrReplacePatch(LobbyPatch patch, LobbyPatcherChanges changes) { }

	private static void ParseLobbyDataRemovePatch(LobbyPatch patch, LobbyPatcherChanges changes) { }

	private static void ParseLobbyPatch(LobbyPatch patch, LobbyPatcherChanges changes) { }

	private static void ParsePlayerAddPatch(LobbyPatch patch, LobbyPatcherChanges changes) { }

	private static void ParsePlayerRemovePatch(LobbyPatch patch, LobbyPatcherChanges changes) { }

	private static void ParsePlayerReplacePatch(LobbyPatch patch, LobbyPatcherChanges changes) { }

	private static void ParseRemovePatch(LobbyPatch patch, LobbyPatcherChanges changes) { }

	private static void ParseRemovePlayerData(int index, LobbyPatch patch, string path, LobbyPatcherChanges changes) { }

	private static void ParseReplacePatch(LobbyPatch patch, LobbyPatcherChanges changes) { }

}

