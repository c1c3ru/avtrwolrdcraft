namespace PWC.Level;

[CreateAssetMenu(menuName = "PazuWorld/Level/Scene Avatars Map")]
public class LevelSceneAvatarMap : ScriptableObject
{
	internal class AvatarData
	{
		public int id; //Field offset: 0x10
		public Vector2 position; //Field offset: 0x14
		public string sceneGuid; //Field offset: 0x20
		public bool isOnPhone; //Field offset: 0x28

		public AvatarData() { }

	}

	private static Dictionary<String, List`1<AvatarData>> _avatarsForScenes; //Field offset: 0x0
	public const string SCECNE_AVATAR_MAP_PATH = "Level/SceneAvatarMap/"; //Field offset: 0x0
	private static Dictionary<Int32, AvatarData> _avatars; //Field offset: 0x8
	private static bool _didLoadData; //Field offset: 0x10
	[FormerlySerializedAs("characters")]
	public List<AvatarData> avatars; //Field offset: 0x18

	public LevelSceneAvatarMap() { }

	public static void LoadDataIfNeeded() { }

	public static bool TryGetAvatar(int avatarId, out AvatarData avatarData) { }

	public static bool TryGetAvatars(string sceneName, out List<AvatarData>& list) { }

}

