namespace PWC;

public static class PWCUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__52_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <ShowGameUpdateMessage>b__52_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public ParticleSystem particleSystem; //Field offset: 0x10
		public bool isSpriteRendererDestroyed; //Field offset: 0x18
		public GameObject clonedLevelItem; //Field offset: 0x20

		public <>c__DisplayClass10_0() { }

		internal void <PlayVanishEffect>b__0() { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass19_0
	{
		public GameObject context; //Field offset: 0x0

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass45_0
	{
		public string str; //Field offset: 0x10
		public int chunkSize; //Field offset: 0x18

		public <>c__DisplayClass45_0() { }

		internal string <SplitString>b__0(int i) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass49_0
	{
		public Action<Int32, Int32> action; //Field offset: 0x10

		public <>c__DisplayClass49_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass49_1
	{
		public int startIndex; //Field offset: 0x10
		public int endIndex; //Field offset: 0x14
		public <>c__DisplayClass49_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass49_1() { }

		internal void <RunInTasks>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public ParticleSystem particleSystem; //Field offset: 0x10
		public bool isLevelItemDestroyed; //Field offset: 0x18
		public GameObject clonedLevelItem; //Field offset: 0x20

		public <>c__DisplayClass8_0() { }

		internal void <PlayVanishEffect>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public ParticleSystem particleSystem; //Field offset: 0x10
		public bool isRendererDestroyed; //Field offset: 0x18
		public GameObject clonedRenderer; //Field offset: 0x20

		public <>c__DisplayClass9_0() { }

		internal void <PlayVanishEffect>b__0() { }

	}

	private static readonly Random _globalRandom; //Field offset: 0x0

	private static PWCUtils() { }

	[CompilerGenerated]
	internal static void <IsValidIndex>g__LogError|19_0(string error, ref <>c__DisplayClass19_0<T>& unnamed_param_1) { }

	public static void Assert(bool condition, string message, object context = null, Type type = null) { }

	public static void AssertEnum(T value, object context = null, Type type = null) { }

	public static Bounds CalculateLocalBoundsFromCShapeModel(CShapeModel cShapeModel) { }

	public static void ClampRectTransformToSize(RectTransform rectTransform, float maxSize) { }

	public static Mesh CreateGridMesh(int width, int height, bool centered = true, float quadSize = 1) { }

	public static string CreateHierarchyLog(Transform transform, Transform stopOnTransform = null, Func<Transform, String> overrideName = null, Predicate<Transform> itemValidator = null) { }

	public static Vector2[] CreateLocalPointsForTouchTest(CShapeModel cShapeModel, int pointsAmountX = 0, int pointsAmountY = 0) { }

	public static void DestroyGeneric(GameObject gameObject) { }

	public static void DestroyGeneric(Component component) { }

	public static Vector2 EvaluateBezier(in Vector2 point1, in Vector2 point2, in Vector2 handle1, in Vector2 handle2, in float t) { }

	public static Bounds GetCameraBounds(Camera camera) { }

	public static void GetChildrenWithPredicate(Transform root, Predicate<Transform> parentCondition, List<Transform> resultList) { }

	public static T GetComponentInParentIncludeInactive(GameObject gameObject) { }

	public static List<T> GetComponentsInImmediateChildren(Transform transform, bool includeInactive = true) { }

	public static Random GetGlobalRandom() { }

	public static string GetListAsString(IList<T> list, Func<T, String> getLineAction, string delimiter = "
", bool isReversed = false) { }

	public static Vector2 GetPointerScreenPosition(int pointerId) { }

	public static float GetRandomNumberInRange(float min, float max) { }

	public static int GetRandomNumberInRange(int min, int max) { }

	public static string GetSceneNameFromSceneId(string sceneId, out string suffix) { }

	public static void GetTopmostComponents(Transform root, List<T> resutls) { }

	public static bool IsAnyComponent(Transform transform, Predicate<T> predicate) { }

	public static bool IsDestroyed(Component compoent) { }

	public static bool IsDestroyed(GameObject gameObject) { }

	public static bool IsObjectRaycastNotBlocked(Transform transform) { }

	private static bool IsSoundNameMusic(string soundName) { }

	public static bool IsValidIndex(IList<T> collection, int index, GameObject context = null, bool logIfError = true) { }

	public static void LogBigLog(string log, bool isError = false, object context = null) { }

	private static void LogBigLogInternal(string log, bool isError, object context = null) { }

	public static void LogErrorWithInfo(string log, GameObject context) { }

	public static void LogErrorWithInfo(string log, Component context) { }

	public static void LogList(string headline, IList<T> list, Func<T, String> getLineAction, bool isReversed = false) { }

	public static void LogWarningWithInfo(string log, GameObject context) { }

	public static void LogWithInfo(string log, GameObject context) { }

	public static void LogWithInfo(string log, Component context) { }

	public static void MigrateAndroidBuildFileFromPrivateToNormalIfNeeded(string fileName) { }

	public static void MoveCameraIfPointerOnScreenEdge(Vector2 pointerScreenPosition, Vector2 pointerPosition, Vector2 lastPointerPosition, float speed = 1, float threshold = 0,2) { }

	public static void PlayVanishEffect(LevelItem levelItem, Transform parent = null, ParticleSystem particleSystem = null, Color color = null, bool isLevelItemDestroyed = false, bool forceCircleShape = false) { }

	public static void PlayVanishEffect(SpriteRenderer spriteRenderer, Transform parent = null, ParticleSystem particleSystem = null, Color color = null, int numberOfParticles = 50, bool isSpriteRendererDestroyed = false) { }

	public static void PlayVanishEffect(Renderer renderer, Transform parent = null, ParticleSystem particleSystem = null, Color color = null, bool isRendererDestroyed = false, bool forceCircleShape = false) { }

	public static void RequestUpdateGame() { }

	public static List<Task> RunInTasks(int collectionCount, Action<Int32, Int32> action) { }

	public static void RunInTasksAndWait(int collectionCount, Action<Int32, Int32> action) { }

	public static void SetGameSoundMute(bool mute) { }

	public static void ShowErrorMessageIfNoMessageActive(string message) { }

	public static void ShowGameUpdateMessage(string title, string text, string buttonText) { }

	public static void ShowMessageIfNoMessageActive(string title, string text, string buttonText, Action onCtaClick = null, bool showCloseButton = true, Action onCloseClick = null, bool showLogo = false) { }

	public static List<String> SplitString(string str, int chunkSize) { }

	public static void SyncMuteStateForSound(AudioSource audioSource) { }

	public static string TruncateString(string value, int maxLength, string truncationSuffix = "…") { }

	public static string TruncateStringForLog(string value) { }

	public static bool TryCancelTween(GameObject gameObject, ref int tweenID, bool callOnComplete = false, bool onlyIfLTDescExists = false) { }

	public static bool TryGetCategoryTypeFromSkinName(SpineType spineType, string skinName, out int categoryType, bool logIferror = true, GameObject context = null) { }

	public static bool TryGetComponentInImmediateChildren(Transform transform, out T result) { }

	public static bool TryGetRootSortingGroup(Transform transform, out SortingGroup sortingGroup) { }

	public static bool TryGetSpriteFromRenderer(Renderer renderer, out Sprite sprite) { }

	public static bool TryGetStorePackTypeFromPackName(string packName, out StorePackType storePackType, bool logErrorIfFailed = true) { }

	public static bool TrySetSpriteToRenderer(Renderer renderer, Sprite sprite) { }

}

