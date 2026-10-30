namespace PWC.Multiplayer;

public static class MPPlayersPicturesManager
{
	private static readonly Dictionary<Int32, Sprite> _pictures; //Field offset: 0x0
	private static readonly Dictionary<Int32, Int32> _avatarIdsForPlayers; //Field offset: 0x8

	private static MPPlayersPicturesManager() { }

	public static void ClearData() { }

	public static void ClearPlayerData(int playerUID) { }

	public static void SetAvatarForPlayer(int playerUID, AvatarSpineData spineData) { }

	public static bool TryGetPicture(int playerUID, out Sprite picture) { }

}

