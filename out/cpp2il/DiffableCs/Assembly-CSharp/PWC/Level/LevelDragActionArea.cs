namespace PWC.Level;

public class LevelDragActionArea : LevelConsumerAreaBase
{
	[CompilerGenerated]
	private sealed class <TrackItems>d__28 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelDragActionArea <>4__this; //Field offset: 0x20

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
		public <TrackItems>d__28(int <>1__state) { }

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

	internal enum ExitReasonType
	{
		None = 0,
		WhileDrag = 1,
		EndDrag = 2,
		AreaDisabled = 3,
		CurrentlyDraggingItemsListIsEmpty = 4,
	}

	private readonly HashSet<LevelItem> _currentItems; //Field offset: 0x58
	private Coroutine _trackItemsCoroutine; //Field offset: 0x60
	private Predicate<LevelItem> _filter; //Field offset: 0x68
	[CompilerGenerated]
	private Action<LevelItem> OnItemEnterAction; //Field offset: 0x70
	[CompilerGenerated]
	private Action<LevelItem, ExitReasonType> OnItemExitAction; //Field offset: 0x78
	[CompilerGenerated]
	private bool <IsPointOnlyInteractionTest>k__BackingField; //Field offset: 0x80
	[CompilerGenerated]
	private bool <IsStrictInteractionTest>k__BackingField; //Field offset: 0x81

	public event Action<LevelItem> OnItemEnterAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelItem, ExitReasonType> OnItemExitAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public bool IsPointOnlyInteractionTest
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public bool IsStrictInteractionTest
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public LevelDragActionArea() { }

	[CompilerGenerated]
	public void add_OnItemEnterAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnItemExitAction(Action<LevelItem, ExitReasonType> value) { }

	protected virtual void Awake() { }

	private void EnsureTrackITems() { }

	private void ExitCurrentTargets(ExitReasonType exitReasonType) { }

	[CompilerGenerated]
	public bool get_IsPointOnlyInteractionTest() { }

	[CompilerGenerated]
	public bool get_IsStrictInteractionTest() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	private void OnLevelItemBeginDrag(LevelItem levelItem) { }

	private void OnLevelItemEndDrag(LevelItem levelItem) { }

	[CompilerGenerated]
	public void remove_OnItemEnterAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnItemExitAction(Action<LevelItem, ExitReasonType> value) { }

	[CompilerGenerated]
	public void set_IsPointOnlyInteractionTest(bool value) { }

	[CompilerGenerated]
	public void set_IsStrictInteractionTest(bool value) { }

	public void SetFilter(Predicate<LevelItem> filter) { }

	private void StopTrackItems() { }

	[IteratorStateMachine(typeof(<TrackItems>d__28))]
	private IEnumerator TrackItems() { }

}

