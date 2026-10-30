namespace PWC.Level;

public class LevelFillableMeshItemHandler : LevelDragActionItemHandlerBase, IHasPersistentData, IRequirePDSceneObject, ILevelFillable, ILevelSpawnDuringGameplay, ILevelConsumer
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public LevelFillableMeshItemHandler <>4__this; //Field offset: 0x10
		public Action onFinish; //Field offset: 0x18

		public <>c__DisplayClass37_0() { }

		internal void <PlayFillingTween>b__0(float value) { }

		internal void <PlayFillingTween>b__1() { }

	}

	[SerializeField]
	private MeshSliced _meshSliced; //Field offset: 0xA0
	[SerializeField]
	private bool _startFull; //Field offset: 0xA8
	[SerializeField]
	private bool _ignorePD; //Field offset: 0xA9
	[SerializeField]
	private float _emptyingDuration; //Field offset: 0xAC
	[SerializeField]
	private UnityEvent _onFull; //Field offset: 0xB0
	[SerializeField]
	private UnityEvent _onEmpty; //Field offset: 0xB8
	private bool _didOnReadyPostLoad; //Field offset: 0xC0
	private bool _isFull; //Field offset: 0xC1
	private bool _hasPersistentData; //Field offset: 0xC2
	private LevelRuntimeColoredMeshHandler _colorHandler; //Field offset: 0xC8
	[CompilerGenerated]
	private Action<Color> OnColorLiquidAction; //Field offset: 0xD0
	[CompilerGenerated]
	private Action<ILevelFillable> OnEmptyingTweenStartAction; //Field offset: 0xD8
	[CompilerGenerated]
	private Action<ILevelFillable> OnEmptyingTweenCompleteAction; //Field offset: 0xE0
	[CompilerGenerated]
	private Action<ILevelFillable> OnFillingTweenStartAction; //Field offset: 0xE8
	[CompilerGenerated]
	private Action<ILevelFillable> OnFillingTweenCompleteAction; //Field offset: 0xF0

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

	public LevelFillableMeshItemHandler() { }

	[CompilerGenerated]
	private void <PlayEmptyingTween>b__34_0(float value) { }

	[CompilerGenerated]
	private void <PlayEmptyingTween>b__34_1() { }

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

	public void Empty() { }

	private void EnsureOnReadyPostLoad() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

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

	public override void SetLiquidColor(Color color) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public override void SnapToState(bool isFull) { }

}

