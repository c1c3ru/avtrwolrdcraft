namespace PWC.Level.ContextualAnimation;

[Extension]
public static class CATargetExtensionMethods
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelCAHandlerBase> <>9__13_0; //Field offset: 0x8
		public static Func<LevelCAHandlerBase, Int32> <>9__13_4; //Field offset: 0x10
		public static Func<LevelCAHandlerBase, Int32> <>9__13_2; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal bool <GetRelevantHandlers>b__13_0(LevelCAHandlerBase x) { }

		internal int <GetRelevantHandlers>b__13_2(LevelCAHandlerBase x) { }

		internal int <GetRelevantHandlers>b__13_4(LevelCAHandlerBase x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public ICATarget target; //Field offset: 0x10
		public LevelCAConfig animationConfig; //Field offset: 0x18
		public int localCounter; //Field offset: 0x20
		public CAPlayType playType; //Field offset: 0x24
		public LevelCAHandlerBase handler; //Field offset: 0x28

		public <>c__DisplayClass1_0() { }

		internal void <PlayContextualAnimation>g__EndAnimation|0() { }

		internal void <PlayContextualAnimation>g__OnCompleteFullCycle|2(TrackEntry trackEntry) { }

		internal void <PlayContextualAnimation>g__OnCompleteNotLooped|3(TrackEntry trackEntry) { }

		internal void <PlayContextualAnimation>g__OnInterruptOrEnd|1(TrackEntry trackEntry) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public ICATarget target; //Field offset: 0x10

		public <>c__DisplayClass13_0() { }

		internal bool <GetRelevantHandlers>b__1(LevelCAHandlerBase x) { }

		internal bool <GetRelevantHandlers>b__3(LevelCAHandlerBase x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public ICATarget target; //Field offset: 0x10

		public <>c__DisplayClass4_0() { }

		internal bool <AddCAHandlersAndUpdateGame>b__0(LevelCAConfig x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public LevelCAHandlerBase caHandlerToUse; //Field offset: 0x10
		public ICATarget target; //Field offset: 0x18
		public LevelCAPD data; //Field offset: 0x20

		public <>c__DisplayClass9_0() { }

		internal void <GetApplyPersistentDataAction>b__0() { }

	}


	[Extension]
	public static void AddCAHandler(ICATarget target, LevelCAHandlerBase handler) { }

	[Extension]
	public static void AddCAHandlerAndUpdateGame(ICATarget target, LevelCAHandlerBase handler) { }

	[Extension]
	public static bool AddCAHandlers(ICATarget target, GameObject gameObject, out List<LevelCAHandlerBase>& addedHandlers, out bool isAtLeastOneRelevant) { }

	[Extension]
	public static void AddCAHandlersAndUpdateGame(ICATarget target, GameObject gameObject) { }

	[Extension]
	public static LevelCAPD CreatePersistentData(ICATarget target) { }

	[Extension]
	public static void EnsureContextualAnimationTypes(ICATarget target) { }

	[Extension]
	public static Action GetApplyPersistentDataAction(ICATarget target, Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	[Extension]
	public static IReadOnlyList<LevelCAHandlerBase> GetRelevantHandlers(ICATarget target) { }

	[Extension]
	public static bool IsAlive(ICATarget target) { }

	[Extension]
	public static void PlayContextualAnimation(ICATarget target, LevelCAHandlerBase handler, LevelCAConfig animationConfig, Nullable<CAPlayType> nullablePlayType = null, float delay = 0) { }

	[Extension]
	public static void RemoveCAHandlerAndUpdateGame(ICATarget target, LevelCAHandlerBase handler, bool playIdleAnimationIfPossible = true) { }

	[Extension]
	public static bool RemoveCAHandlers(ICATarget target, GameObject gameObject, out List<LevelCAHandlerBase>& removedHandlers) { }

	[Extension]
	public static void RemoveCAHandlersAndUpdateGame(ICATarget target, GameObject gameObject, bool playIdleAnimationIfPossible = true) { }

	private static void SetForceSitIfNeeded(ICATarget target) { }

}

