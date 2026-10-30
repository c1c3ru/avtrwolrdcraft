namespace PazuCore.PazuCloud;

public class PazuCloudGameDataManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<Boolean> <>9__19_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <OnGameResume>b__19_1(bool consumeNotConsumedProductsSuccess) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public PazuCloudGameDataManager <>4__this; //Field offset: 0x10
		public Action<Boolean> onFinish; //Field offset: 0x18

		public <>c__DisplayClass24_0() { }

		internal void <SendGameDataCoroutine>b__0(bool success) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public Action<Boolean> onFinish; //Field offset: 0x10

		public <>c__DisplayClass25_0() { }

		internal void <SendGameDataInternal>b__0(Response response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public PazuCloudGameDataManager <>4__this; //Field offset: 0x10
		public Action<Boolean> onFinish; //Field offset: 0x18

		public <>c__DisplayClass26_0() { }

		internal void <GetGameData>b__0(GetGameDataResponse response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass27_0
	{
		public bool success; //Field offset: 0x10
		public PazuCloudGameDataManager <>4__this; //Field offset: 0x18

		public <>c__DisplayClass27_0() { }

		internal void <ProcessConsumable>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass27_1
	{
		public string entitlements; //Field offset: 0x10
		public PazuCloudGameDataManager <>4__this; //Field offset: 0x18

		public <>c__DisplayClass27_1() { }

		internal void <ProcessConsumable>b__2(bool success) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public bool done; //Field offset: 0x10

		public <>c__DisplayClass28_0() { }

		internal void <RetryConsumeNotConsumedProducts>b__0(bool success) { }

		internal bool <RetryConsumeNotConsumedProducts>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass29_0
	{
		public bool editorTest; //Field offset: 0x10
		public PazuCloudGameDataManager <>4__this; //Field offset: 0x18
		public bool isRetrying; //Field offset: 0x20
		public Action<Boolean> onFinish; //Field offset: 0x28
		public Action<Response> <>9__1; //Field offset: 0x30

		public <>c__DisplayClass29_0() { }

		internal void <ConsumeNotConsumedProducts>b__0(GetNotConsumedProductsResponse getNotConsumedResponse) { }

		internal void <ConsumeNotConsumedProducts>b__1(Response consumeResponse) { }

	}

	[CompilerGenerated]
	private sealed class <RetryConsumeNotConsumedProducts>d__28 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PazuCloudGameDataManager <>4__this; //Field offset: 0x20
		private int <triesCounter>5__2; //Field offset: 0x28

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
		public <RetryConsumeNotConsumedProducts>d__28(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <SendGameDataCoroutine>d__24 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PazuCloudGameDataManager <>4__this; //Field offset: 0x20
		public Action<Boolean> onFinish; //Field offset: 0x28
		private <>c__DisplayClass24_0 <>8__1; //Field offset: 0x30
		private float <safeTimer>5__2; //Field offset: 0x38

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
		public <SendGameDataCoroutine>d__24(int <>1__state) { }

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

	[CompilerGenerated]
	private static Action OnBeginConsumeAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Boolean> OnEndConsumeAction; //Field offset: 0x8
	private static Action<String> _entitlementsAdder; //Field offset: 0x10
	private static Action<String> _gameDataSetter; //Field offset: 0x18
	private static Func<String> _gameDataGetter; //Field offset: 0x20
	private static Action _gameDataSaver; //Field offset: 0x28
	private bool _isSendingGameDataInProgress; //Field offset: 0x20
	private bool _isGettingGameDataInProgress; //Field offset: 0x21
	private bool _isConsumeNotConsumedProductsInProgress; //Field offset: 0x22
	private bool _isBuyingConsumablesInProgress; //Field offset: 0x23

	public static event Action OnBeginConsumeAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public static event Action<Boolean> OnEndConsumeAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public PazuCloudGameDataManager() { }

	[CompilerGenerated]
	private void <OnGameResume>b__19_0(bool getGameDataSuccess) { }

	[CompilerGenerated]
	private void <ProcessConsumable>g__onFinish|27_0(bool success) { }

	[CompilerGenerated]
	public static void add_OnBeginConsumeAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnEndConsumeAction(Action<Boolean> value) { }

	private void Awake() { }

	public void BuyConsumable(string productName, string entitlementsJson) { }

	private void ConsumeNotConsumedProducts(Action<Boolean> onFinish = null, bool editorTest = false, bool isRetrying = false) { }

	public void GetGameData(Action<Boolean> onFinish = null) { }

	public static void Init(Func<String> gameDataGetter, Action<String> gameDataSetter, Action<String> entitlementsAdder, Action gameDataSaver) { }

	public bool IsCloudActionInProgress() { }

	public bool IsInitialized(bool logErroIfFalse = false) { }

	private void OnDestroy() { }

	public void OnGameResume() { }

	private void OnSync(SyncType syncType) { }

	private void OnUserMerge() { }

	private void ProcessConsumable(bool editorTest = false) { }

	[CompilerGenerated]
	public static void remove_OnBeginConsumeAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnEndConsumeAction(Action<Boolean> value) { }

	[IteratorStateMachine(typeof(<RetryConsumeNotConsumedProducts>d__28))]
	private IEnumerator RetryConsumeNotConsumedProducts() { }

	public void SendGameData(Action<Boolean> onFinish = null) { }

	[IteratorStateMachine(typeof(<SendGameDataCoroutine>d__24))]
	private IEnumerator SendGameDataCoroutine(Action<Boolean> onFinish = null) { }

	private void SendGameDataInternal(Action<Boolean> onFinish) { }

}

