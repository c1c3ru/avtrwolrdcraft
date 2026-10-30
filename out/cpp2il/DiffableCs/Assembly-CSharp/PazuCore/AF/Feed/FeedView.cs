namespace PazuCore.AF.Feed;

public class FeedView : AddressablesFeatureViewBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__16_0; //Field offset: 0x8
		public static Func<Boolean> <>9__18_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <Start>b__16_0() { }

		internal bool <UpdateFeedViewWhenFinishedGetNewData>b__18_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public FeedItemData itemModel; //Field offset: 0x10

		public <>c__DisplayClass18_0() { }

		internal bool <UpdateFeedViewWhenFinishedGetNewData>b__1(FeedItemView item) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public FeedView <>4__this; //Field offset: 0x20
		private Enumerator<FeedItemView> <>7__wrap1; //Field offset: 0x28

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
		public <Start>d__16(int <>1__state) { }

		private void <>m__Finally1() { }

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
	private sealed class <UpdateFeedViewWhenFinishedGetNewData>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public FeedView <>4__this; //Field offset: 0x20

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
		public <UpdateFeedViewWhenFinishedGetNewData>d__18(int <>1__state) { }

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
	private static bool <IsSceneOpen>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static FeedView <Instance>k__BackingField; //Field offset: 0x8
	[SerializeField]
	private GameObject _feedLayoutPortraitItemPrefab; //Field offset: 0x48
	[SerializeField]
	private GameObject _feedLayoutLayoutLandscapeItemPrefab; //Field offset: 0x50
	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x58
	private Bounds _loadingTexturesAreaBounds; //Field offset: 0x60
	private List<FeedItemView> _feedItems; //Field offset: 0x78
	private List<FeedItemData> _feedItemModels; //Field offset: 0x80
	private bool _landscapeRightContent; //Field offset: 0x88

	public private static FeedView Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private static bool IsSceneOpen
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public FeedView() { }

	protected virtual void Awake() { }

	private void CalculateTexturesLoadingAreaBounds() { }

	public void CloseScene() { }

	[CompilerGenerated]
	public static FeedView get_Instance() { }

	[CompilerGenerated]
	public static bool get_IsSceneOpen() { }

	public bool IsPointInsideLoadingTextureAreaBounds(Vector2 point) { }

	private bool OnBackButton() { }

	protected virtual void OnDestroy() { }

	public void OnScroll(Vector2 value) { }

	public static void OpenScene() { }

	[CompilerGenerated]
	private static void set_Instance(FeedView value) { }

	[CompilerGenerated]
	private static void set_IsSceneOpen(bool value) { }

	[IteratorStateMachine(typeof(<Start>d__16))]
	private IEnumerator Start() { }

	[IteratorStateMachine(typeof(<UpdateFeedViewWhenFinishedGetNewData>d__18))]
	private IEnumerator UpdateFeedViewWhenFinishedGetNewData() { }

}

