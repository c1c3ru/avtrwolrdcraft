namespace PWC.Multiplayer;

public static class MPUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<GameObject, Int32> <>9__37_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <PrepareSceneForMultiplayer>b__37_0(GameObject x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_0
	{
		public int avatarId; //Field offset: 0x10

		public <>c__DisplayClass46_0() { }

		internal bool <IsAvatarInDifferentLevel>b__0(ILevelAvatar x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass53_0
	{
		public MPDataGeneratorHandle dataGeneratorHandle; //Field offset: 0x10
		public Action<MPDataGeneratorHandle> action; //Field offset: 0x18

		public <>c__DisplayClass53_0() { }

		internal void <SetTimer>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass55_0
	{
		public MPDataGeneratorHandle dataGeneratorHandle; //Field offset: 0x10
		public Action<MPDataGeneratorHandle> action; //Field offset: 0x18

		public <>c__DisplayClass55_0() { }

		internal void <LeanTweenDelayCall>b__0() { }

	}

	[CompilerGenerated]
	private static bool <IsInsideRemoteCall>k__BackingField; //Field offset: 0x0
	private const int AVATAR_PLAYER_FACTOR = 1000000; //Field offset: 0x0

	public static bool IsInsideRemoteCall
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		 set { } //Length: 80
	}

	[CompilerGenerated]
	internal static void <EnsureSceneObjectsForMultiplayer>g__EnsureSceneObject|39_0(Transform target, string guidBase, ref int counter) { }

	public static T[] AddValueAtTheBeginning(T[] array, T[] arrayToAdd) { }

	private static void CallActionPostTimer(MPDataGeneratorHandle dataGeneratorHandle, Action<MPDataGeneratorHandle> action) { }

	private static void CopyDirectory(DirectoryInfo source, DirectoryInfo target, ref int recursionCounter, Predicate<DirectoryInfo> condition) { }

	public static void CopyDirectory(string sourceDir, string destinationDir, Predicate<DirectoryInfo> condition = null) { }

	public static string CreateGUID() { }

	public static string CreateGUIDFromRandom(Random random) { }

	public static void DestroyAllGameObjectsInLoadedScenes() { }

	public static void DestroyOtherAvatarsWithTheSameID(ILevelAvatar avatar, bool allowMultiplayerEvent) { }

	private static void EnsureSceneObjectsForMultiplayer(Transform root, string guidBase, ref int counter, bool isFirstIteraction = true) { }

	public static int FixAvatarIdForHostData(int id) { }

	[CompilerGenerated]
	public static bool get_IsInsideRemoteCall() { }

	public static int GetAvatarIdForPlayerUID(int avatarId, int playerUID) { }

	public static Byte[] GetBytesFromDataStream(ref DataStreamReader stream) { }

	public static int GetComponentIndex(Component component) { }

	public static string GetDataAsString(MPDataBase data) { }

	public static MPDataBase GetDataFromNetworkMessageString(string message) { }

	public static int GetIndexOfNetworkEntityBaseInterface(Component component) { }

	public static int GetOriginalAvatarIdFromMPAvatarId(int avatarId) { }

	public static int GetPlayerUIDForAvatarId(int avatarId) { }

	public static int GetRandomNumberInRange(int min, int max) { }

	public static float GetRandomNumberInRange(float min, float max) { }

	public static string GetStringFromDataStream(ref DataStreamReader stream) { }

	public static bool IsAvatarInDifferentLevel(int avatarId, bool editor_logSceneNameIfTrue) { }

	public static bool IsAvatarPlayerInGame(int avatarId) { }

	public static bool IsHostPlayerUID(int playerUID) { }

	public static bool IsLevelEvent(MPDataType eventType) { }

	public static bool IsMyPlayerInScene(string sceneName) { }

	public static bool IsOwnAvatarId(int avatarId) { }

	public static LTDescr LeanTweenDelayCall(GameObject gameObject, float duration, Action<MPDataGeneratorHandle> action) { }

	public static LTDescr LeanTweenDelayCall(GameObject gameObject, float duration, MPDataGeneratorHandle dataGeneratorHandle, Action<MPDataGeneratorHandle> action) { }

	public static void PrepareItemForDrop(LevelItem levelItem, bool isFlipped, Vector2 fromPosition, MPDataType triggerFromDataType) { }

	public static void PrepareSceneForMultiplayer(Scene scene, bool forPDPrefabs) { }

	public static void PrepareTransformForMultiplayer(Transform target, string guidBase) { }

	public static void RemovePlayerFromGame(int playerUID) { }

	public static void SendMessage(IMultiplayer_NetworkIdentityBase target, object objectData = null, MPEventIdentifierData idData = null) { }

	[CompilerGenerated]
	public static void set_IsInsideRemoteCall(bool value) { }

	public static void SetSceneDataAsCurrentData(MPSceneData sceneData) { }

	public static Coroutine SetTimer(MonoBehaviour monoBehaviour, float duration, MPDataGeneratorHandle dataGeneratorHandle, Action<MPDataGeneratorHandle> action) { }

	public static Coroutine SetTimer(MonoBehaviour monoBehaviour, float duration, Action<MPDataGeneratorHandle> action) { }

	public static bool ShouldAddGuidPrefixForDataGenerator(MPDataType eventType) { }

	public static bool ShouldBroadcastGlobalEvent(MPDataType eventType) { }

	public static bool ShouldShowAvatarInPhone(AvatarSpineData avatarSpineData) { }

	public static void ShowErrorMessageIfNoMessageActive(string message) { }

	public static List<T[]> SliceArrayToArrays(T[] array, int maxLength) { }

	public static void TryClearOneCallGenerator(MPDataGeneratorHandle handler) { }

	public static bool TryCreateMPAvatarData(int avatarId, out MPAvatarData avatarData) { }

	private static bool TryGetIdForPlayerPicture(List<Int32> ids, out int pictureId) { }

	public static bool TryGetInstanceOfType(object obj, out T result, bool logErrorOnFailure = true) { }

	public static bool TryGetSceneData(string sceneId, out MPSceneData sceneData) { }

	public static bool TryGetSceneObject(string sceneGuid, out PDSceneObject sceneObject) { }

	public static bool TryGetSpineDataForPlayerPicture(out AvatarSpineData avatarSpineData) { }

	public static bool TryGoToAvatarScene(int avatarId) { }

	public static void TrySetOneCallGuidGenerator(MPDataGeneratorHandle handler) { }

	public static void TrySetOneCallRandomGenerator(MPDataGeneratorHandle handler) { }

	public static string Unzip(Byte[] bytes) { }

	public static void WriteBytesToDataStream(ref DataStreamWriter writer, Byte[] bytes) { }

	public static void WriteStringToDataStream(ref DataStreamWriter writer, string value) { }

	public static void WriteStringToDataStream(ref DataStreamWriter writer, Byte[] bytes) { }

	public static Byte[] Zip(string text) { }

}

