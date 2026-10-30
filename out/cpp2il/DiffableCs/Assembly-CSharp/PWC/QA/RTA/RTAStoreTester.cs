namespace PWC.QA.RTA;

public static class RTAStoreTester
{
	[CompilerGenerated]
	private struct <<TryClaimItem_Internal>g__EnsureClaimMade|13_1>d : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Boolean> <>t__builder; //Field offset: 0x8
		private TaskAwaiter<Boolean> <>u__1; //Field offset: 0x20

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <<TryClaimItem_Internal>g__TryClickClaimButton|13_2>d : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Boolean> <>t__builder; //Field offset: 0x8
		public Component component; //Field offset: 0x20
		private TaskAwaiter<Boolean> <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__12_3; //Field offset: 0x8
		public static Predicate<Button> <>9__13_4; //Field offset: 0x10
		public static Func<Button, Boolean> <>9__13_7; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal bool <TestStorePackItemAsync_Internal>b__12_3() { }

		internal bool <TryClaimItem_Internal>b__13_4(Button b) { }

		internal bool <TryClaimItem_Internal>b__13_7(Button b) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public StoreData storeData; //Field offset: 0x10

		public <>c__DisplayClass10_0() { }

		internal void <CacheStoreDataItems>b__0() { }

		internal bool <CacheStoreDataItems>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public int itemIndex; //Field offset: 0x10

		public <>c__DisplayClass11_0() { }

		internal bool <StartTestAsync>b__0(ValueTuple<Int32, Item> i) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		private struct <<TestStorePackItemAsync_Internal>g__ClickStoreButton|1>d : IAsyncStateMachine
		{
			public int <>1__state; //Field offset: 0x0
			public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
			public <>c__DisplayClass12_0 <>4__this; //Field offset: 0x20
			private string <sceneName>5__2; //Field offset: 0x28
			private TaskAwaiter<Boolean> <>u__1; //Field offset: 0x30
			private TaskAwaiter <>u__2; //Field offset: 0x38
			private TaskAwaiter<String> <>u__3; //Field offset: 0x40

			private override void MoveNext() { }

			[DebuggerHidden]
			private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

		}

		public StoreClaimItemCloudResponse response; //Field offset: 0x10
		public Item item; //Field offset: 0x18

		public <>c__DisplayClass12_0() { }

		internal bool <TestStorePackItemAsync_Internal>b__2() { }

		[AsyncStateMachine(typeof(<<TestStorePackItemAsync_Internal>g__ClickStoreButton|1>d))]
		internal Task<String> <TestStorePackItemAsync_Internal>g__ClickStoreButton|1() { }

		internal void <TestStorePackItemAsync_Internal>g__SetResponse|0(StoreClaimItemCloudResponse claimItemSuccessResponse, ref bool didOverride) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public StorePackItemBase itemStorePackItem; //Field offset: 0x10

		public <>c__DisplayClass13_0() { }

		internal bool <TryClaimItem_Internal>b__3() { }

		internal void <TryClaimItem_Internal>g__OnFocused|0(StorePackItemBase itemBase) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_1
	{
		public StoreClaimItemCloudResponse response; //Field offset: 0x10

		public <>c__DisplayClass13_1() { }

		internal bool <TryClaimItem_Internal>b__6() { }

		internal void <TryClaimItem_Internal>g__OnResponse|5(StoreClaimItemCloudResponse cloudResponse) { }

	}

	[CompilerGenerated]
	private struct <CacheStoreDataItems>d__10 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		private <>c__DisplayClass10_0 <>8__1; //Field offset: 0x20
		private HashSet<Int32> <_cachedIndexes>5__2; //Field offset: 0x28
		private TaskAwaiter<Boolean> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <StartTestAsync>d__11 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<RTAErrorData>> <>t__builder; //Field offset: 0x8
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"itemIndex", "item"})]
		public List<ValueTuple`2<Int32, Item>> items; //Field offset: 0x20
		private Stopwatch <stopWatch>5__2; //Field offset: 0x28
		private string <directory>5__3; //Field offset: 0x30
		private RTALogger <logger>5__4; //Field offset: 0x38
		private List<RTAErrorData> <notWorkingPacks>5__5; //Field offset: 0x40
		private TaskAwaiter <>u__1; //Field offset: 0x48
		private TaskAwaiter<List`1<RTAErrorData>> <>u__2; //Field offset: 0x50
		private int <itemDataIndex>5__6; //Field offset: 0x58
		private Item <item>5__7; //Field offset: 0x60
		private string <packIdentifier>5__8; //Field offset: 0x68
		private TaskAwaiter<List`1<String>> <>u__3; //Field offset: 0x70

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <TestStorePackItemAsync_Internal>d__12 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<String>> <>t__builder; //Field offset: 0x8
		public Item item; //Field offset: 0x20
		public string parentDirectory; //Field offset: 0x28
		private <>c__DisplayClass12_0 <>8__1; //Field offset: 0x30
		public int itemIndex; //Field offset: 0x38
		private List<String> <errors>5__2; //Field offset: 0x40
		private string <name>5__3; //Field offset: 0x48
		private string <directory>5__4; //Field offset: 0x50
		private RTALogger <logger>5__5; //Field offset: 0x58
		private string <unloadStoreSceneError>5__6; //Field offset: 0x60
		private TaskAwaiter<String> <>u__1; //Field offset: 0x68
		private TaskAwaiter <>u__2; //Field offset: 0x70
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"error", "warnings"})]
		private TaskAwaiter<ValueTuple`2<String, List`1<String>>> <>u__3; //Field offset: 0x78
		private string <currentWorldSceneName>5__7; //Field offset: 0x80
		private TaskAwaiter<Boolean> <>u__4; //Field offset: 0x88
		private bool <isAvatarMakerPack>5__8; //Field offset: 0x90
		private bool <isFoundABox>5__9; //Field offset: 0x91
		private DeliverySystemDrone <deliverySystemDrone>5__10; //Field offset: 0x98
		private LevelDropArea <dropArea>5__11; //Field offset: 0xA0
		private List<LevelItem> <childItems>5__12; //Field offset: 0xA8
		private LevelItem <childItem>5__13; //Field offset: 0xB0
		private Enumerator<LevelItem> <>7__wrap13; //Field offset: 0xB8
		private LevelPDBulkDataShopPack <bulkDataPack>5__15; //Field offset: 0xD0

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <TryClaimItem_Internal>d__13 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"error", "warnings"})]
		public AsyncTaskMethodBuilder<ValueTuple`2<String, List`1<String>>> <>t__builder; //Field offset: 0x8
		public int itemIndex; //Field offset: 0x20
		private <>c__DisplayClass13_0 <>8__1; //Field offset: 0x28
		public Item item; //Field offset: 0x30
		private <>c__DisplayClass13_1 <>8__2; //Field offset: 0x38
		private TaskAwaiter<Boolean> <>u__1; //Field offset: 0x40
		private TaskAwaiter <>u__2; //Field offset: 0x48
		private List<String> <warnings>5__2; //Field offset: 0x50
		private string <error>5__3; //Field offset: 0x58

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private static HashSet<String> _ignoredGroupKeys; //Field offset: 0x0
	private static Dictionary<InventoryFlagType, String> _flagsToPacksSpecialCasesDictionary; //Field offset: 0x8
	private static HashSet<String> _packsWithoutBox; //Field offset: 0x10
	private static HashSet<String> _packsToSkip; //Field offset: 0x18
	private static int DELAY_AFTER_OPEN_PACK_MS; //Field offset: 0x20
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"itemIndex", "item"})]
	private static List<ValueTuple`2<Int32, Item>> _cachedItems; //Field offset: 0x28
	private static bool _isCurrentlyCachingItems; //Field offset: 0x30

	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"itemIndex", "item"})]
	public static List<ValueTuple`2<Int32, Item>> CachedItems
	{
		 get { } //Length: 88
	}

	private static RTAStoreTester() { }

	[AsyncStateMachine(typeof(<<TryClaimItem_Internal>g__EnsureClaimMade|13_1>d))]
	[CompilerGenerated]
	internal static Task<Boolean> <TryClaimItem_Internal>g__EnsureClaimMade|13_1() { }

	[AsyncStateMachine(typeof(<<TryClaimItem_Internal>g__TryClickClaimButton|13_2>d))]
	[CompilerGenerated]
	internal static Task<Boolean> <TryClaimItem_Internal>g__TryClickClaimButton|13_2(Component component) { }

	[AsyncStateMachine(typeof(<CacheStoreDataItems>d__10))]
	public static Task CacheStoreDataItems() { }

	public static void ClearCachedItems() { }

	public static List<ValueTuple`2<Int32, Item>> get_CachedItems() { }

	private static bool IsCurrentSceneAvatarMaker_Internal() { }

	[AsyncStateMachine(typeof(<StartTestAsync>d__11))]
	public static Task<List`1<RTAErrorData>> StartTestAsync(List<ValueTuple`2<Int32, Item>> items = null) { }

	[AsyncStateMachine(typeof(<TestStorePackItemAsync_Internal>d__12))]
	private static Task<List`1<String>> TestStorePackItemAsync_Internal(int itemIndex, Item item, string parentDirectory) { }

	[AsyncStateMachine(typeof(<TryClaimItem_Internal>d__13))]
	private static Task<ValueTuple`2<String, List`1<String>>> TryClaimItem_Internal(int itemIndex, Item item) { }

}

