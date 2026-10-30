namespace PWC.QA.RTA;

public static class RTAManager
{
	[CompilerGenerated]
	private struct <Init>d__3 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		private TaskAwaiter <>u__1; //Field offset: 0x20
		private TaskAwaiter<Dictionary`2<LevelWorldType, List`1<LevelType>>> <>u__2; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <PerformTests_Internal>d__13 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public bool testStore; //Field offset: 0x20
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"itemIndex", "item"})]
		public List<ValueTuple`2<Int32, Item>> items; //Field offset: 0x28
		public bool testLevels; //Field offset: 0x30
		public Dictionary<LevelWorldType, List`1<LevelType>> levelsToTest; //Field offset: 0x38
		public bool runWithSwitchers; //Field offset: 0x40
		private RTALogger <currentLogger>5__2; //Field offset: 0x48
		private Stopwatch <stopWatch>5__3; //Field offset: 0x50
		private List<RTAErrorData> <storeErrorsList>5__4; //Field offset: 0x58
		private TaskAwaiter<List`1<RTAErrorData>> <>u__1; //Field offset: 0x60

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <StartTestsAsync>d__12 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public bool testStore; //Field offset: 0x20
		public bool testLevels; //Field offset: 0x21
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"itemIndex", "item"})]
		public List<ValueTuple`2<Int32, Item>> items; //Field offset: 0x28
		public Dictionary<LevelWorldType, List`1<LevelType>> levelsToTest; //Field offset: 0x30
		public bool runWithSwitchers; //Field offset: 0x38
		private TaskAwaiter <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	internal enum TestPlayMode
	{
		None = 0,
		Testing = 1,
		Stopped = 2,
		Paused = 3,
	}

	private static TestPlayMode playMode; //Field offset: 0x0
	private static bool _isInitiating; //Field offset: 0x4

	public static string GetDirectoryPath() { }

	[AsyncStateMachine(typeof(<Init>d__3))]
	public static Task Init() { }

	public static bool IsActive() { }

	public static bool IsPaused() { }

	public static bool IsStopped() { }

	public static bool IsTesting() { }

	public static void PauseTests() { }

	[AsyncStateMachine(typeof(<PerformTests_Internal>d__13))]
	private static Task PerformTests_Internal(bool testStore, bool testLevels, List<ValueTuple`2<Int32, Item>> items, Dictionary<LevelWorldType, List`1<LevelType>> levelsToTest, bool runWithSwitchers) { }

	[AsyncStateMachine(typeof(<StartTestsAsync>d__12))]
	public static Task StartTestsAsync(bool testStore, bool testLevels, List<ValueTuple`2<Int32, Item>> items = null, Dictionary<LevelWorldType, List`1<LevelType>> levelsToTest = null, bool runWithSwitchers = true) { }

	public static void StopTests() { }

	public static void UnpauseTests() { }

	private static void UploadZipToCloud_Internal() { }

	private static void ZipRootDirectory_Internal() { }

}

