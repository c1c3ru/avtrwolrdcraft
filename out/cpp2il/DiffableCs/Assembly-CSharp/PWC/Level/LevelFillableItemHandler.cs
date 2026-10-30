namespace PWC.Level;

public class LevelFillableItemHandler : LevelDragActionItemHandlerBase, IHasPersistentData, IRequirePDSceneObject, ILevelFillable, ILevelSpawnDuringGameplay, ILevelConsumer
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public LevelFillableItemHandler <>4__this; //Field offset: 0x10
		public Action onFinish; //Field offset: 0x18

		public <>c__DisplayClass41_0() { }

		internal void <PlayFillingTween>b__0() { }

	}

	[SerializeField]
	private GameObject _liquid; //Field offset: 0xA0
	[SerializeField]
	private bool _startFull; //Field offset: 0xA8
	[SerializeField]
	private bool _isTransparent; //Field offset: 0xA9
	[SerializeField]
	private bool _ignorePD; //Field offset: 0xAA
	[SerializeField]
	private bool _dontFillOnDrag; //Field offset: 0xAB
	[SerializeField]
	[Space]
	private UnityEvent _onFullAction; //Field offset: 0xB0
	[SerializeField]
	private UnityEvent _onEmptyAction; //Field offset: 0xB8
	private bool _didGetFullPosition; //Field offset: 0xC0
	private bool _didOnReadyPostLoad; //Field offset: 0xC1
	private bool _isFull; //Field offset: 0xC2
	private bool _hasPersistentData; //Field offset: 0xC3
	private Vector2 _fullPosition; //Field offset: 0xC4
	private LevelRuntimeColoredSpriteHandler _colorHandler; //Field offset: 0xD0
	[CompilerGenerated]
	private Action<Color> OnColorLiquidAction; //Field offset: 0xD8
	[CompilerGenerated]
	private Action<ILevelFillable> OnEmptyingTweenStartAction; //Field offset: 0xE0
	[CompilerGenerated]
	private Action<ILevelFillable> OnEmptyingTweenCompleteAction; //Field offset: 0xE8
	[CompilerGenerated]
	private Action<ILevelFillable> OnFillingTweenStartAction; //Field offset: 0xF0
	[CompilerGenerated]
	private Action<ILevelFillable> OnFillingTweenCompleteAction; //Field offset: 0xF8

	public override event Action<Color> OnColorLiquidAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override event Action<ILevelFillable> OnEmptyingTweenCompleteAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override event Action<ILevelFillable> OnEmptyingTweenStartAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override event Action<ILevelFillable> OnFillingTweenCompleteAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override event Action<ILevelFillable> OnFillingTweenStartAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelFillableItemHandler() { }

	[CompilerGenerated]
	private void <PlayEmptyingTween>b__38_0() { }

	[CompilerGenerated]
	public override void add_OnColorLiquidAction(Action<Color> value) { }

	[CompilerGenerated]
	public override void add_OnEmptyingTweenCompleteAction(Action<ILevelFillable> value) { }

	[CompilerGenerated]
	public override void add_OnEmptyingTweenStartAction(Action<ILevelFillable> value) { }

	[CompilerGenerated]
	public override void add_OnFillingTweenCompleteAction(Action<ILevelFillable> value) { }

	[CompilerGenerated]
	public override void add_OnFillingTweenStartAction(Action<ILevelFillable> value) { }

	protected virtual void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public float GetEmptyLiquidYPosition() { }

	public override Color GetLiquidColor() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual bool IsConsumerGoodTarget(ILevelConsumer consumer) { }

	public override bool IsFull() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected override void OnEmptyingTweenComplete() { }

	protected override void OnEmptyingTweenStart() { }

	protected virtual void OnEnable() { }

	protected override void OnFillingTweenComplete() { }

	protected override void OnFillingTweenStart() { }

	private void OnItemLand(LevelDropArea dropArea) { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

	public override void PlayEmptyingTween(float duration) { }

	public void PlayFillingTween(Color color) { }

	public override void PlayFillingTween(float duration, Color color, Action onFinish = null) { }

	private override ILevelEntity PWC.Level.ILevelConsumer.GetEntity() { }

	private override GameShape PWC.Level.ILevelConsumer.GetGameShape() { }

	[CompilerGenerated]
	public override void remove_OnColorLiquidAction(Action<Color> value) { }

	[CompilerGenerated]
	public override void remove_OnEmptyingTweenCompleteAction(Action<ILevelFillable> value) { }

	[CompilerGenerated]
	public override void remove_OnEmptyingTweenStartAction(Action<ILevelFillable> value) { }

	[CompilerGenerated]
	public override void remove_OnFillingTweenCompleteAction(Action<ILevelFillable> value) { }

	[CompilerGenerated]
	public override void remove_OnFillingTweenStartAction(Action<ILevelFillable> value) { }

	private void SetFullPositionIfNeeded() { }

	public override void SetLiquidColor(Color color) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public override void SnapToState(bool isFull) { }

}

