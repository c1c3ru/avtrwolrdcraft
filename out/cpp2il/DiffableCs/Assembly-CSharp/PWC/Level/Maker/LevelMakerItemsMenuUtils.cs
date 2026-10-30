namespace PWC.Level.Maker;

public static class LevelMakerItemsMenuUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<KeyValuePair`2<String, CategoryData>, String> <>9__20_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <MarkNewPacks>b__20_0(KeyValuePair<String, CategoryData> x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public GameObject gameObject; //Field offset: 0x10
		public EventSystem currentEventSystem; //Field offset: 0x18

		public <>c__DisplayClass13_0() { }

		internal void <AnimateItemsToLevelMakerMenu>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_1
	{
		public GameObject instance; //Field offset: 0x10
		public bool isEvenIteration; //Field offset: 0x18
		public Vector3 fromScale; //Field offset: 0x1C
		public Vector2 toScale; //Field offset: 0x28

		public <>c__DisplayClass13_1() { }

		internal void <AnimateItemsToLevelMakerMenu>b__1(float val, float ratio) { }

		internal void <AnimateItemsToLevelMakerMenu>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <AnimateItemsToLevelMakerMenu>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GameObject gameObject; //Field offset: 0x20
		public float delayBeforeStart; //Field offset: 0x28
		public List<String> prefabGuids; //Field offset: 0x30
		private <>c__DisplayClass13_1 <>8__1; //Field offset: 0x38
		public string packName; //Field offset: 0x40
		private <>c__DisplayClass13_0 <>8__2; //Field offset: 0x48
		private GameObject <safeTweenTarget>5__2; //Field offset: 0x50
		private int <safeTweenId>5__3; //Field offset: 0x58
		private Vector2 <spawnPosition>5__4; //Field offset: 0x5C
		private WaitForSeconds <waitDelay>5__5; //Field offset: 0x68
		private Vector2 <tweenDestinationPosition>5__6; //Field offset: 0x70
		private int <i>5__7; //Field offset: 0x78

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <AnimateItemsToLevelMakerMenu>d__13(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	internal class ViewedPacks
	{
		public HashSet<String> packs; //Field offset: 0x10

		public ViewedPacks() { }

	}


	[CompilerGenerated]
	internal static float <GetInstanceWorldBounds>g__Round|9_0(float value) { }

	[CompilerGenerated]
	internal static void <OnClaimedPackForTheFirstTime>g__MarkNewPackIfNeeded|18_0(string packName, DataType dataType) { }

	[IteratorStateMachine(typeof(<AnimateItemsToLevelMakerMenu>d__13))]
	private static IEnumerator AnimateItemsToLevelMakerMenu(GameObject gameObject, List<String> prefabGuids, string packName, float delayBeforeStart) { }

	public static void ClearPackNewFlag(string packName, DataType dataType) { }

	private static string GetArtAssetsPrefix(DataType dataType) { }

	public static Sprite GetBackground(string categoryName, DataType dataType) { }

	public static Sprite GetCategoryIcon(string categoryName, bool isSmall, DataType dataType) { }

	public static Sprite GetCategoryTitle(string categoryName, DataType dataType) { }

	public static Bounds GetInstanceWorldBounds(GameObject instance, IList<SpriteRenderer> spriteRenderers) { }

	public static Sprite GetItemsSection(string itemsSection, bool isPressed, DataType dataType) { }

	private static string GetNewPackPlayerPrefsKey(string packName, DataType dataType) { }

	public static Sprite GetSubcategoryIcon(string iconName, bool isSmall, DataType dataType) { }

	public static Sprite GetTag(string categoryName, DataType dataType) { }

	public static bool IsInMakerMenu(MonoBehaviour monoBehaviour, out List<String>& prefabGuids, ref string packName) { }

	public static bool IsPackMarkedAsNew(string packName, DataType dataType) { }

	public static Sprite LoadSpriteFromResources(string spritePathPrefix, string spriteRelativePath, DataType _) { }

	private static void MarkNewPack(string packName, DataType dataType) { }

	public static void MarkNewPacks(DataType dataType) { }

	public static void OnClaimedPackForTheFirstTime(string packName) { }

	public static void PrepareInstanceForUI(string prefabGuid, GameObject instance, List<SpriteRenderer> spriteRenderersToFill, bool visibleOnlyInsideMask) { }

	public static bool TryAnimateItemsToLevelMakerMenu(MonoBehaviour monoBehaviour, float timeToSpawn, string packName = null) { }

	public static bool WillBeAnimatedToLevelMakerMenuWithNoPackName(MonoBehaviour monoBehaviour, out string packName) { }

}

