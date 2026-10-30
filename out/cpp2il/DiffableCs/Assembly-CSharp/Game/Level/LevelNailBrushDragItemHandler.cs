namespace Game.Level;

public class LevelNailBrushDragItemHandler : LevelDragActionItemHandlerBase, ILevelDragActionCharacterAreaItemHandler, ILevelDragActionItemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public bool delayFinished; //Field offset: 0x10
		public LevelNailBrushDragItemHandler <>4__this; //Field offset: 0x18
		public LevelCharacter character; //Field offset: 0x20
		public bool brushMovementFinished; //Field offset: 0x28

		public <>c__DisplayClass23_0() { }

		internal void <PaintRoutine>b__0() { }

		internal bool <PaintRoutine>b__1() { }

		internal void <PaintRoutine>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public LevelNailBrushDragItemHandler <>4__this; //Field offset: 0x10
		public Action onComplete; //Field offset: 0x18

		public <>c__DisplayClass24_0() { }

		internal void <StartBrushMovement>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <PaintRoutine>d__23 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelNailBrushDragItemHandler <>4__this; //Field offset: 0x20
		public LevelCharacter character; //Field offset: 0x28
		private <>c__DisplayClass23_0 <>8__1; //Field offset: 0x30
		private int <delayTweenId>5__2; //Field offset: 0x38

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
		public <PaintRoutine>d__23(int <>1__state) { }

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

	private const float _paintDelay = 0,5; //Field offset: 0x0
	[SerializeField]
	protected GameObject _spriteRenderer; //Field offset: 0xA0
	[SerializeField]
	protected CharacterCategoryType _categoryType; //Field offset: 0xA8
	[SerializeField]
	protected string _skinName; //Field offset: 0xB0
	[SerializeField]
	protected bool _isGradient; //Field offset: 0xB8
	[SerializeField]
	protected Color _color; //Field offset: 0xBC
	[ConditionalField("_isGradient", True, True, (array) null)]
	[SerializeField]
	protected Color _secondColor; //Field offset: 0xCC
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xE0
	[SerializeField]
	private string _soundName; //Field offset: 0xE8
	[SerializeField]
	private SpriteRenderer _nailPolishDropletColor; //Field offset: 0xF0
	protected string _fullSkinName; //Field offset: 0xF8
	private Coroutine _paintingCoroutine; //Field offset: 0x100
	private int _delayedCallTweenID; //Field offset: 0x108
	private bool _isDragged; //Field offset: 0x10C
	private bool _isProcessing; //Field offset: 0x10D
	private LevelCharacter _currentTarget; //Field offset: 0x110

	public CharacterCategoryType CategoryType
	{
		 get { } //Length: 8
	}

	public LevelNailBrushDragItemHandler() { }

	[CompilerGenerated]
	private void <OnEndDrag>b__29_0() { }

	protected virtual void Awake() { }

	private void CancelCurrentProcess() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public CharacterCategoryType get_CategoryType() { }

	protected virtual void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	protected virtual void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	public void OnSpineEventFromCAOnSelf(LevelCharacter character) { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected override void OnTargetEnterCharacterHand(LevelCharacter character, bool shouldPlaySound = true) { }

	protected override void OnTargetEnterOtherItem(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

	protected override void OnTargetExitCharacterHand(LevelCharacter character) { }

	protected override void OnTargetExitOtherItem(ILevelConsumer target) { }

	[IteratorStateMachine(typeof(<PaintRoutine>d__23))]
	private IEnumerator PaintRoutine(LevelCharacter character) { }

	protected virtual bool PerformDragCondition(ILevelConsumer consumer) { }

	private override AreaType PWC.Level.ILevelDragActionCharacterAreaItemHandler.GetAreaTypeToCheck() { }

	protected override void ResetColor() { }

	public void SetData(LevelCharacterMakeupData characterMakeupData) { }

	private void StartBrushMovement(Action onComplete) { }

	private void StopAllTweens() { }

}

