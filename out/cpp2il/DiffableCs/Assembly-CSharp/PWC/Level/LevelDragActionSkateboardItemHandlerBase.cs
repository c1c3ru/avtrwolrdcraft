namespace PWC.Level;

public class LevelDragActionSkateboardItemHandlerBase : LevelDragActionItemHandlerBase, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <UpdateTransformByRampSlope>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelDragActionSkateboardItemHandlerBase <>4__this; //Field offset: 0x20

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
		public <UpdateTransformByRampSlope>d__20(int <>1__state) { }

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

	[SerializeField]
	private bool _isSitArea; //Field offset: 0xA0
	[ConditionalField("_isSitArea", True, True, (array) null)]
	[SerializeField]
	private LevelSitArea _sitArea; //Field offset: 0xA8
	[ConditionalField("_isSitArea", False, True, (array) null)]
	[SerializeField]
	private LevelDropArea _skateboardDropArea; //Field offset: 0xB0
	[SerializeField]
	protected LevelSkateboardItemHandlerBase _skateboardHandler; //Field offset: 0xB8
	protected Coroutine _skateboardTransformUpdateCoroutine; //Field offset: 0xC0
	private Vector2 _closestPosition; //Field offset: 0xC8

	public LevelDragActionSkateboardItemHandlerBase() { }

	protected virtual void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual bool IsStrictInteractionTest() { }

	private void OnAvatarEndDropAction(LevelAvatarRestAreaBase arg1, ILevelAvatar arg2) { }

	protected virtual void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnItemDropOnSkateboard(LevelItem target) { }

	private void OnLevelPostInit() { }

	private bool OnOverrideOnDropBehaviorEvent(LevelItem levelItem, PointerEventData pointerEventData) { }

	public override void OnSpawnDuringGameplay() { }

	private void OnSyncPositionEvent(DragDropItemBase item, Vector2 pointerPos) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

	protected void Start() { }

	[IteratorStateMachine(typeof(<UpdateTransformByRampSlope>d__20))]
	protected IEnumerator UpdateTransformByRampSlope() { }

}

