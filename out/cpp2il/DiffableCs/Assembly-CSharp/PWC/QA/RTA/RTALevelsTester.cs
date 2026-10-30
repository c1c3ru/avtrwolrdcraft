namespace PWC.QA.RTA;

public static class RTALevelsTester
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ChangeWorldButton, LevelWorldType> <>9__8_0; //Field offset: 0x8
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"building", "levelType"})]
		public static Func<ValueTuple`2<Transform, LevelType>, Single> <>9__8_1; //Field offset: 0x10
		public static Func<KeyValuePair`2<LevelWorldType, List`1<LevelType>>, String> <>9__12_0; //Field offset: 0x18
		public static Predicate<String> <>9__12_1; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal LevelWorldType <GetAllCachedLevelTypesAsync>b__8_0(ChangeWorldButton b) { }

		internal float <GetAllCachedLevelTypesAsync>b__8_1(ValueTuple<Transform, LevelType> item) { }

		internal string <StartTestAsync>b__12_0(KeyValuePair<LevelWorldType, List`1<LevelType>> w) { }

		internal bool <StartTestAsync>b__12_1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public LevelType levelType; //Field offset: 0x10

		public <>c__DisplayClass13_0() { }

		internal bool <TestWorldByNameAndGetErrorsAsync_Internal>b__0(WorldBuilding b) { }

		internal bool <TestWorldByNameAndGetErrorsAsync_Internal>b__1(WorldBuildingLevel b) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		private struct <<TestBuildingByLevelTypeAsync_Internal>g__TryEnterLevelFromBuilding|0>d : IAsyncStateMachine
		{
			public int <>1__state; //Field offset: 0x0
			public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
			public <>c__DisplayClass14_0 <>4__this; //Field offset: 0x20
			private TaskAwaiter<String> <>u__1; //Field offset: 0x28
			private TaskAwaiter<Boolean> <>u__2; //Field offset: 0x30

			private override void MoveNext() { }

			[DebuggerHidden]
			private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

		}

		public Type buildingType; //Field offset: 0x10
		public string sceneName; //Field offset: 0x18
		public LevelType levelType; //Field offset: 0x20

		public <>c__DisplayClass14_0() { }

		[AsyncStateMachine(typeof(<<TestBuildingByLevelTypeAsync_Internal>g__TryEnterLevelFromBuilding|0>d))]
		internal Task<String> <TestBuildingByLevelTypeAsync_Internal>g__TryEnterLevelFromBuilding|0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public string worldName; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal bool <TryMoveToWorld_Internal>b__0(ChangeWorldButton b) { }

	}

	[CompilerGenerated]
	private struct <GetAllCachedLevelTypesAsync>d__8 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<LevelType>> <>t__builder; //Field offset: 0x8
		private TaskAwaiter<String> <>u__1; //Field offset: 0x20
		private IEnumerator<LevelWorldType> <>7__wrap1; //Field offset: 0x28
		private LevelWorldType <worldType>5__3; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetAllLevelsToTestAsync>d__10 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Dictionary`2<LevelWorldType, List`1<LevelType>>> <>t__builder; //Field offset: 0x8
		public int count; //Field offset: 0x20
		public int startIndex; //Field offset: 0x24
		private TaskAwaiter<List`1<LevelType>> <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <StartTestAsync>d__12 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<RTAErrorData>> <>t__builder; //Field offset: 0x8
		public Dictionary<LevelWorldType, List`1<LevelType>> levelsToTest; //Field offset: 0x20
		public bool runWithSwitchers; //Field offset: 0x28
		private Stopwatch <stopWatch>5__2; //Field offset: 0x30
		private string <name>5__3; //Field offset: 0x38
		private string <directory>5__4; //Field offset: 0x40
		private RTALogger <logger>5__5; //Field offset: 0x48
		private List<LevelType> <levelsToTestList>5__6; //Field offset: 0x50
		private List<RTAErrorData> <failedWorldNameWithErrors>5__7; //Field offset: 0x58
		private TaskAwaiter <>u__1; //Field offset: 0x60
		private TaskAwaiter<List`1<RTAErrorData>> <>u__2; //Field offset: 0x68
		private TaskAwaiter<String> <>u__3; //Field offset: 0x70
		private TaskAwaiter<Dictionary`2<LevelWorldType, List`1<LevelType>>> <>u__4; //Field offset: 0x78
		private int <i>5__8; //Field offset: 0x80
		private string <worldName>5__9; //Field offset: 0x88
		private TaskAwaiter<List`1<String>> <>u__5; //Field offset: 0x90

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <TestBuildingByLevelTypeAsync_Internal>d__14 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<String>> <>t__builder; //Field offset: 0x8
		public Type buildingType; //Field offset: 0x20
		public LevelType levelType; //Field offset: 0x28
		public string parentDirectory; //Field offset: 0x30
		public string worldName; //Field offset: 0x38
		private <>c__DisplayClass14_0 <>8__1; //Field offset: 0x40
		public bool runWithSwitchers; //Field offset: 0x48
		private List<String> <errors>5__2; //Field offset: 0x50
		private string <filesName>5__3; //Field offset: 0x58
		private string <directory>5__4; //Field offset: 0x60
		private RTALogger <logger>5__5; //Field offset: 0x68
		private string <clickBuildErrorMessage>5__6; //Field offset: 0x70
		private string <sceneLoadError>5__7; //Field offset: 0x78
		private string <error>5__8; //Field offset: 0x80
		private TaskAwaiter <>u__1; //Field offset: 0x88
		private TaskAwaiter<String> <>u__2; //Field offset: 0x90
		private LevelLevelSwitcher[] <switchers>5__9; //Field offset: 0x98
		private int <i>5__10; //Field offset: 0xA0

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <TestSwitcherFlowAsync_Internal>d__15 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
		public string originalSceneName; //Field offset: 0x20
		public int switcherIndex; //Field offset: 0x28
		public string parentDirectory; //Field offset: 0x30
		public string worldName; //Field offset: 0x38
		private string <screenShotName>5__2; //Field offset: 0x40
		private LevelLevelSwitcher <switcher>5__3; //Field offset: 0x48
		private string <switcherName>5__4; //Field offset: 0x50
		private string <targetScene>5__5; //Field offset: 0x58
		private string <error>5__6; //Field offset: 0x60
		private TaskAwaiter <>u__1; //Field offset: 0x68
		private TaskAwaiter<Boolean> <>u__2; //Field offset: 0x70
		private TaskAwaiter<String> <>u__3; //Field offset: 0x78

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <TestWorldByNameAndGetErrorsAsync_Internal>d__13 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<String>> <>t__builder; //Field offset: 0x8
		public string worldName; //Field offset: 0x20
		public string parentDirectory; //Field offset: 0x28
		public List<LevelType> levelTypes; //Field offset: 0x30
		public bool runWithSwitchers; //Field offset: 0x38
		private List<String> <errors>5__2; //Field offset: 0x40
		private string <directory>5__3; //Field offset: 0x48
		private RTALogger <logger>5__4; //Field offset: 0x50
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"buildingType", "levelType"})]
		private List<ValueTuple`2<Type, LevelType>> <buildingsToTest>5__5; //Field offset: 0x58
		private TaskAwaiter <>u__1; //Field offset: 0x60
		private TaskAwaiter<List`1<String>> <>u__2; //Field offset: 0x68
		private TaskAwaiter<String> <>u__3; //Field offset: 0x70
		private int <i>5__6; //Field offset: 0x78

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <TryMoveToWorld_Internal>d__9 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
		public string worldName; //Field offset: 0x20
		private <>c__DisplayClass9_0 <>8__1; //Field offset: 0x28
		private TaskAwaiter<String> <>u__1; //Field offset: 0x30
		private TaskAwaiter<Boolean> <>u__2; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const string LEVEL_TO_WORLD_MAP_PATH = "Level/WorldViews/LevelTypeToWorldTypeMap"; //Field offset: 0x0
	private static LevelTypeToWorldTypeMap _levelTypeToWorldTypeMap; //Field offset: 0x0
	private static HashSet<LevelType> _allCachedLevelTypes; //Field offset: 0x8
	private static bool _isCaching; //Field offset: 0x10
	private static Dictionary<String, String> _sceneNameToFolderName; //Field offset: 0x18

	public static List<LevelType> AllCachedLevelTypes
	{
		 get { } //Length: 112
	}

	private static RTALevelsTester() { }

	public static void ClearAllCachedLevelTypes() { }

	public static List<LevelType> DictionaryToList(Dictionary<LevelWorldType, List`1<LevelType>> dictionary) { }

	public static List<LevelType> get_AllCachedLevelTypes() { }

	[AsyncStateMachine(typeof(<GetAllCachedLevelTypesAsync>d__8))]
	public static Task<List`1<LevelType>> GetAllCachedLevelTypesAsync() { }

	[AsyncStateMachine(typeof(<GetAllLevelsToTestAsync>d__10))]
	public static Task<Dictionary`2<LevelWorldType, List`1<LevelType>>> GetAllLevelsToTestAsync(int startIndex = 0, int count = -1) { }

	[AsyncStateMachine(typeof(<StartTestAsync>d__12))]
	public static Task<List`1<RTAErrorData>> StartTestAsync(Dictionary<LevelWorldType, List`1<LevelType>> levelsToTest = null, bool runWithSwitchers = true) { }

	[AsyncStateMachine(typeof(<TestBuildingByLevelTypeAsync_Internal>d__14))]
	private static Task<List`1<String>> TestBuildingByLevelTypeAsync_Internal(LevelType levelType, Type buildingType, string worldName, string parentDirectory, bool runWithSwitchers) { }

	[AsyncStateMachine(typeof(<TestSwitcherFlowAsync_Internal>d__15))]
	private static Task<String> TestSwitcherFlowAsync_Internal(int switcherIndex, string worldName, string parentDirectory, string originalSceneName) { }

	[AsyncStateMachine(typeof(<TestWorldByNameAndGetErrorsAsync_Internal>d__13))]
	private static Task<List`1<String>> TestWorldByNameAndGetErrorsAsync_Internal(string worldName, string parentDirectory, List<LevelType> levelTypes, bool runWithSwitchers) { }

	[AsyncStateMachine(typeof(<TryMoveToWorld_Internal>d__9))]
	private static Task<String> TryMoveToWorld_Internal(string worldName) { }

}

