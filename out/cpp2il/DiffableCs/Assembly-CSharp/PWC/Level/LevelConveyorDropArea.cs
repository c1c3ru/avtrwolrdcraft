namespace PWC.Level;

public class LevelConveyorDropArea : LevelDropArea
{
	[CompilerGenerated]
	private sealed class <Move>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelConveyorDropArea <>4__this; //Field offset: 0x20
		private Bounds <areaBounds>5__2; //Field offset: 0x28

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
		public <Move>d__38(int <>1__state) { }

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

	internal enum TilingMovementType
	{
		WhenObjectsMoving = 0,
		WhenObjectsOn = 1,
		Always = 2,
	}

	[SerializeField]
	private Renderer _rendererToAnimate; //Field offset: 0xD8
	[SerializeField]
	private Vector2 _startingOffset; //Field offset: 0xE0
	[SerializeField]
	private Vector2 _movementDirection; //Field offset: 0xE8
	[SerializeField]
	private float _movementSpeed; //Field offset: 0xF0
	[SerializeField]
	private TilingMovementType _tileMovementType; //Field offset: 0xF4
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0xF8
	private Material _material; //Field offset: 0x100
	private Vector2 _currentOffset; //Field offset: 0x108
	private readonly int _MainTexID; //Field offset: 0x110
	private Coroutine _movementCoroutine; //Field offset: 0x118
	private Vector2 _baseMovementVector; //Field offset: 0x120
	private List<LevelItem> _movingItems; //Field offset: 0x128
	[CompilerGenerated]
	private Action<LevelConveyorDropArea> OnMovementBeginAction; //Field offset: 0x130
	[CompilerGenerated]
	private Action<LevelConveyorDropArea> OnMovementEndAction; //Field offset: 0x138
	[CompilerGenerated]
	private Action<LevelConveyorDropArea, LevelItem> OnItemStopMovingAction; //Field offset: 0x140

	public event Action<LevelConveyorDropArea, LevelItem> OnItemStopMovingAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelConveyorDropArea> OnMovementBeginAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelConveyorDropArea> OnMovementEndAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public IReadOnlyList<LevelItem> MovingItems
	{
		 get { } //Length: 8
	}

	public LevelConveyorDropArea() { }

	[CompilerGenerated]
	public void add_OnItemStopMovingAction(Action<LevelConveyorDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnMovementBeginAction(Action<LevelConveyorDropArea> value) { }

	[CompilerGenerated]
	public void add_OnMovementEndAction(Action<LevelConveyorDropArea> value) { }

	protected virtual void Awake() { }

	private void EnsureMovement() { }

	public IReadOnlyList<LevelItem> get_MovingItems() { }

	private void Init() { }

	public bool IsMoving() { }

	[IteratorStateMachine(typeof(<Move>d__38))]
	private IEnumerator Move() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

	private void PlayConveyorSound(LevelConveyorDropArea levelConveyorDropArea) { }

	[CompilerGenerated]
	public void remove_OnItemStopMovingAction(Action<LevelConveyorDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnMovementBeginAction(Action<LevelConveyorDropArea> value) { }

	[CompilerGenerated]
	public void remove_OnMovementEndAction(Action<LevelConveyorDropArea> value) { }

	private bool ShouldMoveRenderer(Bounds areaBounds, LevelItem levelItem, Vector2 vector) { }

	private void StopConveyorSound(LevelConveyorDropArea levelConveyorDropArea) { }

	private void StopMovement() { }

	private void SyncState() { }

	private void UpdateMovement(float deltaTime) { }

	private void UpdateTextureOffset() { }

}

