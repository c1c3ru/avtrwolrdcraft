namespace PWC.Level.Water;

public class LevelWaterAreaItemHandler : LevelWaterAreaItemHandlerBase, IMultiplayer_PrepareForDrag, IMultiplayer_PrepareForDrop
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<LevelWaterAreaObstacle, CShape> <>9__40_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal CShape <InWaterRoutineCoroutine>b__40_0(LevelWaterAreaObstacle x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_0
	{
		public LevelCharacter character; //Field offset: 0x10

		public <>c__DisplayClass46_0() { }

		internal void <PlayFloatingTween>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_1
	{
		public LevelToddler toddler; //Field offset: 0x10

		public <>c__DisplayClass46_1() { }

		internal void <PlayFloatingTween>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <InWaterRoutineCoroutine>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelWaterAreaItemHandler <>4__this; //Field offset: 0x20
		private bool <cachedIsInDeepWater>5__2; //Field offset: 0x28
		private Vector2 <lastFramePosition>5__3; //Field offset: 0x2C
		private Quaternion <rotation>5__4; //Field offset: 0x34
		private float <lastDraggingTime>5__5; //Field offset: 0x44
		private bool <isCharacterOrToddler>5__6; //Field offset: 0x48
		private bool <shouldSyncWaterPositionForCharacter>5__7; //Field offset: 0x49
		private List<CShape> <obstacles>5__8; //Field offset: 0x50

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
		public <InWaterRoutineCoroutine>d__40(int <>1__state) { }

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

	private LevelItem _levelItem; //Field offset: 0x60
	private Coroutine _inWaterRoutineCoroutine; //Field offset: 0x68
	[CompilerGenerated]
	private bool <IsInWaterRoutineRunning>k__BackingField; //Field offset: 0x70
	private bool _didInit; //Field offset: 0x71
	private bool _didAwake; //Field offset: 0x72
	private bool _isDropAreaRealesedItem; //Field offset: 0x73
	private LevelWaterAreaSwimItemHandler _swimItemHandler; //Field offset: 0x78
	private LevelWaterAreaItemHandler _rootItemHandler; //Field offset: 0x80
	private LevelWaterAreaItemHandler _parentItemHandler; //Field offset: 0x88
	private readonly HashSet<LevelWaterAreaItemHandler> _childrenItemHandler; //Field offset: 0x90
	[CompilerGenerated]
	private bool <IgnoreEndLandEvent>k__BackingField; //Field offset: 0x98

	public bool IgnoreEndLandEvent
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public private bool IsInWaterRoutineRunning
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public LevelWaterAreaItemHandler() { }

	private void Awake() { }

	public void AwakeIfNeeded() { }

	public void CreateWaterLineIfNeeded() { }

	public void DetachFromCurrentItemHandlerParent() { }

	private void FixWaterLineWhileSwimming(float scaleFactor, float xAltScale, float padding) { }

	[CompilerGenerated]
	public bool get_IgnoreEndLandEvent() { }

	[CompilerGenerated]
	public bool get_IsInWaterRoutineRunning() { }

	public void GetOutOfWater() { }

	private LevelWaterAreaItemHandler GetRootItemHandler() { }

	public void InitIfNeeded() { }

	[IteratorStateMachine(typeof(<InWaterRoutineCoroutine>d__40))]
	private IEnumerator InWaterRoutineCoroutine() { }

	private bool IsWaterLineVisibleInParents() { }

	private void OnBeforeDetachFromParent(LevelItem item, Transform parent) { }

	private void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnBeginDropCharacterOnResetArea(LevelAvatarRestAreaBase resetArea) { }

	private void OnBeginLand(LevelDropArea dropArea) { }

	private void OnBeginLandOnArea(LevelConsumerAreaBase area) { }

	private void OnCharacterPutClothing(string skinName) { }

	private void OnChildDropAreaItemBeginDrop(LevelDropArea dropArea, LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnEndLand(LevelDropArea dropArea) { }

	private void OnPutOtherItemInCharacterBone(LevelItem levelItem) { }

	private void OnThisItemPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	private bool OverrideCharacterPlayProperIdleAnimation() { }

	public virtual void PlayFloatingTween(float delay = 0) { }

	private override void PWC.Multiplayer.IMultiplayer_PrepareForDrag.Multiplayer_PrepareForDrag() { }

	private override void PWC.Multiplayer.IMultiplayer_PrepareForDrop.Multiplayer_PrepareForDrop(MPDataType tiggerFromDataType) { }

	[CompilerGenerated]
	public void set_IgnoreEndLandEvent(bool value) { }

	[CompilerGenerated]
	private void set_IsInWaterRoutineRunning(bool value) { }

	private void SetCurveMultiplier(float curveMultiplier) { }

	public void SetItemHandlerParent(LevelWaterAreaItemHandler parentItemHandler) { }

	private bool ShouldShowWaterLine() { }

	public void StartInWaterRoutine() { }

	public void StopInWaterRoutine() { }

	private void SyncWaterLine() { }

	public void SyncWaterPosition() { }

}

