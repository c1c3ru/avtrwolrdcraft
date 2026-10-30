namespace PWC.Level;

public class LevelFillableHandler : LevelConsumerAreaBase, ILevelFillable, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public LevelFillableHandler <>4__this; //Field offset: 0x10
		public Action onFinish; //Field offset: 0x18

		public <>c__DisplayClass35_0() { }

		internal void <PlayFillingTween>b__0() { }

	}

	[SerializeField]
	private GameObject _liquid; //Field offset: 0x58
	[SerializeField]
	private bool _startFull; //Field offset: 0x60
	[SerializeField]
	private bool _isTransparent; //Field offset: 0x61
	[SerializeField]
	private bool _ignorePD; //Field offset: 0x62
	private bool _didGetFullPosition; //Field offset: 0x63
	private bool _isFull; //Field offset: 0x64
	private bool _hasPersistentData; //Field offset: 0x65
	private Vector2 _fullPosition; //Field offset: 0x68
	private LevelRuntimeColoredSpriteHandler _colorHandler; //Field offset: 0x70
	[CompilerGenerated]
	private Action<Color> OnColorLiquidAction; //Field offset: 0x78
	[CompilerGenerated]
	private Action<ILevelFillable> OnEmptyingTweenStartAction; //Field offset: 0x80
	[CompilerGenerated]
	private Action<ILevelFillable> OnEmptyingTweenCompleteAction; //Field offset: 0x88
	[CompilerGenerated]
	private Action<ILevelFillable> OnFillingTweenStartAction; //Field offset: 0x90
	[CompilerGenerated]
	private Action<ILevelFillable> OnFillingTweenCompleteAction; //Field offset: 0x98
	public UnityEvent OnFullAction; //Field offset: 0xA0
	public UnityEvent OnEmptyAction; //Field offset: 0xA8

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

	public LevelFillableHandler() { }

	[CompilerGenerated]
	private void <PlayEmptyingTween>b__32_0() { }

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

	public float GetEmptyLiquidYPosition() { }

	public override Color GetLiquidColor() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override bool IsFull() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected override void OnEmptyingTweenComplete() { }

	protected override void OnEmptyingTweenStart() { }

	protected virtual void OnEnable() { }

	protected override void OnFillingTweenComplete() { }

	protected override void OnFillingTweenStart() { }

	private void OnLevelPostInit() { }

	public override void PlayEmptyingTween(float duration) { }

	public override void PlayFillingTween(float duration, Color color, Action onFinish = null) { }

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

