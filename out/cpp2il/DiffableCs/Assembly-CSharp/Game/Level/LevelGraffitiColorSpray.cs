namespace Game.Level;

public class LevelGraffitiColorSpray : LevelDragActionItemHandlerBase, ILevelMakerUIMenuItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass40_0
	{
		public LevelGraffitiColorSpray <>4__this; //Field offset: 0x10
		public Vector2 pointerPosition; //Field offset: 0x18

		public <>c__DisplayClass40_0() { }

		internal void <IsInPlaceFlag>b__0() { }

		internal void <IsInPlaceFlag>b__1() { }

		internal float <IsInPlaceFlag>g__DistanceBetweenPositions|2() { }

		internal void <IsInPlaceFlag>g__EndShaking|5(bool animEnd) { }

		internal void <IsInPlaceFlag>g__ShakeAnim|3(float goTo, Action onEndAction) { }

		internal void <IsInPlaceFlag>g__StartPainting|4() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass40_1
	{
		public Action onEndAction; //Field offset: 0x10

		public <>c__DisplayClass40_1() { }

		internal void <IsInPlaceFlag>b__6() { }

	}

	[CompilerGenerated]
	private sealed class <Paint>d__41 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelGraffitiColorSpray <>4__this; //Field offset: 0x20

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
		public <Paint>d__41(int <>1__state) { }

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
	private SpriteRenderer _spriteHolder; //Field offset: 0xA0
	[SerializeField]
	private SpriteRenderer _topSprite; //Field offset: 0xA8
	[SerializeField]
	private SpriteRenderer _bottomSprite; //Field offset: 0xB0
	[SerializeField]
	private Color _sprayColor; //Field offset: 0xB8
	[SerializeField]
	private Color _decorativeColor; //Field offset: 0xC8
	[SerializeField]
	private Sprite _baseBursh; //Field offset: 0xD8
	[SerializeField]
	private LevelSingleItemDropArea _nozzleDropArea; //Field offset: 0xE0
	[SerializeField]
	private SpriteRenderer _brushSpriteRenderer; //Field offset: 0xE8
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0xF0
	[SerializeField]
	private GameSoundPlayer _gameSoundPlayer; //Field offset: 0xF8
	[SerializeField]
	private string _spraySoundName; //Field offset: 0x100
	[SerializeField]
	private string _shakeSoundName; //Field offset: 0x108
	[SerializeField]
	private string _nozzleSoundName; //Field offset: 0x110
	[SerializeField]
	private float _standStillTimeThreshold; //Field offset: 0x118
	private readonly List<LevelPaintableArea> _currentTargets; //Field offset: 0x120
	private Coroutine _paintingCoroutine; //Field offset: 0x128
	private LTexture _brush; //Field offset: 0x130
	private Vector2 _lastPlace; //Field offset: 0x138
	private bool _isShaking; //Field offset: 0x140
	private bool _didShakeOnce; //Field offset: 0x141
	private int _delayedCallTweenID; //Field offset: 0x144
	private bool _canStartPainting; //Field offset: 0x148
	private bool _hasShapedMask; //Field offset: 0x149
	private bool _isDragged; //Field offset: 0x14A
	private float _distanceSensetivityThreshold; //Field offset: 0x14C
	private int _targetsCounter; //Field offset: 0x150

	public LevelGraffitiColorSpray() { }

	[CompilerGenerated]
	private void <OnEndDrag>b__33_0() { }

	protected virtual void Awake() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	private void InitColor() { }

	private void InitNozzleIfNeeded() { }

	protected void IsInPlaceFlag(Vector2 pointerPosition) { }

	protected virtual bool IsStrictInteractionTest() { }

	protected virtual void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnItemBeginDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

	[IteratorStateMachine(typeof(<Paint>d__41))]
	private IEnumerator Paint() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	public void StartSprayEffects() { }

	public void StopSprayEffects() { }

}

