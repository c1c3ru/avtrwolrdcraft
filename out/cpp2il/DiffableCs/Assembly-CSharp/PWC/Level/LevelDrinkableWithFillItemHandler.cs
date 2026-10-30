namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelDrinkableWithFillItemHandler : LevelDrinkableItemHandler, IHasPersistentData, IRequirePDSceneObject, ILevelFillable, ILevelMakerUIMenuItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public LevelDrinkableWithFillItemHandler <>4__this; //Field offset: 0x10
		public Action onFinish; //Field offset: 0x18

		public <>c__DisplayClass37_0() { }

		internal void <PlayFillingTween>b__0() { }

	}

	[SerializeField]
	protected GameObject _liquid; //Field offset: 0xB0
	[SerializeField]
	private bool _startFull; //Field offset: 0xB8
	[SerializeField]
	private bool _isTransparent; //Field offset: 0xB9
	private Vector2 _fullPosition; //Field offset: 0xBC
	protected bool _isFull; //Field offset: 0xC4
	private Color _liquidColor; //Field offset: 0xC8
	private bool _didGetFullPosition; //Field offset: 0xD8
	private bool _hasPersistentData; //Field offset: 0xD9
	private PDPrefab _pdPrefab; //Field offset: 0xE0
	[CompilerGenerated]
	private Action<Color> OnColorLiquidAction; //Field offset: 0xE8
	[CompilerGenerated]
	private Action<ILevelFillable> OnEmptyingTweenStartAction; //Field offset: 0xF0
	[CompilerGenerated]
	private Action<ILevelFillable> OnEmptyingTweenCompleteAction; //Field offset: 0xF8
	[CompilerGenerated]
	private Action<ILevelFillable> OnFillingTweenStartAction; //Field offset: 0x100
	[CompilerGenerated]
	private Action<ILevelFillable> OnFillingTweenCompleteAction; //Field offset: 0x108

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
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public override event Action<ILevelFillable> OnFillingTweenStartAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public LevelDrinkableWithFillItemHandler() { }

	[CompilerGenerated]
	private void <PlayEmptyingTween>b__34_0() { }

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

	public virtual bool CanBeDrinked() { }

	public override float GetEmptyLiquidYPosition() { }

	public override Color GetLiquidColor() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual bool IsConsumerGoodTarget(ILevelConsumer consumer) { }

	public override bool IsFull() { }

	protected virtual bool IsValidTarget(ILevelConsumer consumer) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected override void OnEmptyingTweenComplete() { }

	protected override void OnEmptyingTweenStart() { }

	protected virtual void OnEnable() { }

	protected override void OnFillingTweenComplete() { }

	protected override void OnFillingTweenStart() { }

	protected virtual void OnItemLand(LevelDropArea dropArea) { }

	private void OnLevelPostInit() { }

	private void OnSpawn(bool multiplayer_ensureGuids) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	public override void PlayEmptyingTween(float duration) { }

	public override void PlayFillingTween(float duration, Color color, Action onFinish = null) { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

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

	protected virtual void TryDropInteraction(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData) { }

	protected virtual void TryDropInteractionWithCharacter(LevelCharacter character, ref bool didInteract, ref MPEventIdentifierData mpData) { }

}

