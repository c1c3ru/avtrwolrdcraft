namespace PWC;

public abstract class DragDropItemBase : InteractableItem, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IMultiplayer_InputListener
{
	[CompilerGenerated]
	private sealed class <SyncPosition>d__75 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public DragDropItemBase <>4__this; //Field offset: 0x20

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
		public <SyncPosition>d__75(int <>1__state) { }

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

	internal sealed class TryOverrideGetPointerPositionDelegate : MulticastDelegate
	{

		public TryOverrideGetPointerPositionDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(DragDropItemBase item, out Vector2 position, AsyncCallback callback, object object) { }

		public override bool EndInvoke(out Vector2 position, IAsyncResult result) { }

		public override bool Invoke(DragDropItemBase item, out Vector2 position) { }

	}

	[CompilerGenerated]
	private bool <IsDragging>k__BackingField; //Field offset: 0x39
	protected Vector2 _initialPosition; //Field offset: 0x3C
	protected Camera _camera; //Field offset: 0x48
	protected Coroutine _syncPositionCoroutine; //Field offset: 0x50
	protected Vector2 _fixedOffset; //Field offset: 0x58
	protected bool _useSmoothOffset; //Field offset: 0x60
	protected bool _useDragPositionOffset; //Field offset: 0x61
	protected Transform _transform; //Field offset: 0x68
	protected float _clampPositionDistance; //Field offset: 0x70
	protected bool _freezeX; //Field offset: 0x74
	protected bool _freezeY; //Field offset: 0x75
	protected int _pointerId; //Field offset: 0x78
	private bool _isPointerDown; //Field offset: 0x7C
	private Vector2 _onPointerDownPosition; //Field offset: 0x80
	private Vector2 _onBeginDragPosition; //Field offset: 0x88
	protected Vector2 _dragPositionOffset; //Field offset: 0x90
	private PDSceneObject _sceneObject; //Field offset: 0x98
	private float _multiplayer_lastTransformSyncTime; //Field offset: 0xA0
	private readonly List<Vector2> _multiplayer_dragPositions; //Field offset: 0xA8
	public bool allowChangePosition; //Field offset: 0xB0
	[CompilerGenerated]
	private Action<DragDropItemBase, PointerEventData> OnClickAction; //Field offset: 0xB8
	[CompilerGenerated]
	private Action<DragDropItemBase, PointerEventData> OnBeginDragAction; //Field offset: 0xC0
	[CompilerGenerated]
	private Action<DragDropItemBase, PointerEventData> OnPreEndDragAction; //Field offset: 0xC8
	[CompilerGenerated]
	private Action<DragDropItemBase, PointerEventData> OnEndDragAction; //Field offset: 0xD0
	[CompilerGenerated]
	private Action<DragDropItemBase, Vector2> OnSyncPositionAction; //Field offset: 0xD8
	[CompilerGenerated]
	private Func<DragDropItemBase, Vector2, Boolean> OverrideSyncPositionAction; //Field offset: 0xE0
	[CompilerGenerated]
	private Func<DragDropItemBase, PointerEventData, Boolean> TryOverridePreBeginDragAction; //Field offset: 0xE8
	[CompilerGenerated]
	private Func<DragDropItemBase, PointerEventData, Boolean> TryOverridePreEndDragAction; //Field offset: 0xF0
	[CompilerGenerated]
	private TryOverrideGetPointerPositionDelegate TryOverrideGetPointerPositionForDragAction; //Field offset: 0xF8
	[CompilerGenerated]
	private bool <IgnoreXDragOffset>k__BackingField; //Field offset: 0x100
	[CompilerGenerated]
	private bool <IgnoreYDragOffset>k__BackingField; //Field offset: 0x101
	[CompilerGenerated]
	private bool <Multiplayer_IsInsideLocalInputCall>k__BackingField; //Field offset: 0x102
	[CompilerGenerated]
	private MPDataGeneratorHandle <Multiplayer_DataGeneratorHandle>k__BackingField; //Field offset: 0x108

	public event Action<DragDropItemBase, PointerEventData> OnBeginDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<DragDropItemBase, PointerEventData> OnClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<DragDropItemBase, PointerEventData> OnEndDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<DragDropItemBase, PointerEventData> OnPreEndDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<DragDropItemBase, Vector2> OnSyncPositionAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Func<DragDropItemBase, Vector2, Boolean> OverrideSyncPositionAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event TryOverrideGetPointerPositionDelegate TryOverrideGetPointerPositionForDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Func<DragDropItemBase, PointerEventData, Boolean> TryOverridePreBeginDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Func<DragDropItemBase, PointerEventData, Boolean> TryOverridePreEndDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public bool IgnoreXDragOffset
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public bool IgnoreYDragOffset
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public bool IsDragging
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public MPDataGeneratorHandle Multiplayer_DataGeneratorHandle
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 16
	}

	public private bool Multiplayer_IsInsideLocalInputCall
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	protected DragDropItemBase() { }

	[CompilerGenerated]
	public void add_OnBeginDragAction(Action<DragDropItemBase, PointerEventData> value) { }

	[CompilerGenerated]
	public void add_OnClickAction(Action<DragDropItemBase, PointerEventData> value) { }

	[CompilerGenerated]
	public void add_OnEndDragAction(Action<DragDropItemBase, PointerEventData> value) { }

	[CompilerGenerated]
	public void add_OnPreEndDragAction(Action<DragDropItemBase, PointerEventData> value) { }

	[CompilerGenerated]
	public void add_OnSyncPositionAction(Action<DragDropItemBase, Vector2> value) { }

	[CompilerGenerated]
	public void add_OverrideSyncPositionAction(Func<DragDropItemBase, Vector2, Boolean> value) { }

	[CompilerGenerated]
	public void add_TryOverrideGetPointerPositionForDragAction(TryOverrideGetPointerPositionDelegate value) { }

	[CompilerGenerated]
	public void add_TryOverridePreBeginDragAction(Func<DragDropItemBase, PointerEventData, Boolean> value) { }

	[CompilerGenerated]
	public void add_TryOverridePreEndDragAction(Func<DragDropItemBase, PointerEventData, Boolean> value) { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public bool get_IgnoreXDragOffset() { }

	[CompilerGenerated]
	public bool get_IgnoreYDragOffset() { }

	[CompilerGenerated]
	public bool get_IsDragging() { }

	[CompilerGenerated]
	public MPDataGeneratorHandle get_Multiplayer_DataGeneratorHandle() { }

	[CompilerGenerated]
	public bool get_Multiplayer_IsInsideLocalInputCall() { }

	protected override Vector2 GetDragPositionForThisFramePostModifications(Vector2 position) { }

	protected override Vector2 GetDragPositionForThisFramePreModifications(Vector2 position) { }

	public Vector2 GetPointerPosition() { }

	public Vector2 GetPointerPositionForDrag() { }

	private Vector2 GetPointerScreenPosition() { }

	protected override bool Multiplayer_CanSendTransformEvent() { }

	protected void Multiplayer_OnPostDataGeneratorRequired() { }

	protected void Multiplayer_OnPreDataGeneratorRequired() { }

	protected override bool Multiplayer_ShouldAddParentToTransformEvent() { }

	protected void Multiplayer_TrySendTransfrom(Transform target) { }

	private void OnActiveSceneChanged(Scene from, Scene to) { }

	private void OnApplicationPause(bool pause) { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	protected override void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnEndDrag(PointerEventData eventData) { }

	protected override void OnEndDragInternal(PointerEventData eventData) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected override void OnPointerClickInternal(PointerEventData eventData) { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	public virtual void OnPointerUp(PointerEventData eventData) { }

	protected override void OnSyncPosition(Vector2 pointerPosition) { }

	private override void PWC.Multiplayer.IMultiplayer_InputListener.Multiplayer_OnPostInput() { }

	private override void PWC.Multiplayer.IMultiplayer_InputListener.Multiplayer_OnPreInput() { }

	[CompilerGenerated]
	public void remove_OnBeginDragAction(Action<DragDropItemBase, PointerEventData> value) { }

	[CompilerGenerated]
	public void remove_OnClickAction(Action<DragDropItemBase, PointerEventData> value) { }

	[CompilerGenerated]
	public void remove_OnEndDragAction(Action<DragDropItemBase, PointerEventData> value) { }

	[CompilerGenerated]
	public void remove_OnPreEndDragAction(Action<DragDropItemBase, PointerEventData> value) { }

	[CompilerGenerated]
	public void remove_OnSyncPositionAction(Action<DragDropItemBase, Vector2> value) { }

	[CompilerGenerated]
	public void remove_OverrideSyncPositionAction(Func<DragDropItemBase, Vector2, Boolean> value) { }

	[CompilerGenerated]
	public void remove_TryOverrideGetPointerPositionForDragAction(TryOverrideGetPointerPositionDelegate value) { }

	[CompilerGenerated]
	public void remove_TryOverridePreBeginDragAction(Func<DragDropItemBase, PointerEventData, Boolean> value) { }

	[CompilerGenerated]
	public void remove_TryOverridePreEndDragAction(Func<DragDropItemBase, PointerEventData, Boolean> value) { }

	[CompilerGenerated]
	public void set_IgnoreXDragOffset(bool value) { }

	[CompilerGenerated]
	public void set_IgnoreYDragOffset(bool value) { }

	[CompilerGenerated]
	protected void set_IsDragging(bool value) { }

	[CompilerGenerated]
	public void set_Multiplayer_DataGeneratorHandle(MPDataGeneratorHandle value) { }

	[CompilerGenerated]
	private void set_Multiplayer_IsInsideLocalInputCall(bool value) { }

	public void SetFixedOffset(Vector2 value) { }

	public void SetMainCamera() { }

	public void SetUseDragPositionOffset(bool value) { }

	protected override void StartSyncPosition() { }

	protected override void StopSyncPosition() { }

	public void SyncDragPositionOffsetToCurrentState() { }

	[IteratorStateMachine(typeof(<SyncPosition>d__75))]
	protected override IEnumerator SyncPosition() { }

}

