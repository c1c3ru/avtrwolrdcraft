namespace PWC.Level;

public class LevelDragActionHorseHandlerBase : LevelDragActionItemHandlerBase, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public LevelDragActionHorseHandlerBase <>4__this; //Field offset: 0x10
		public ExitReasonType exitReasonType; //Field offset: 0x18

		public <>c__DisplayClass17_0() { }

		internal void <HandleJumpObstacleExit>b__0(TrackEntry x) { }

	}

	[SerializeField]
	private LevelHorse _levelHorse; //Field offset: 0xA0

	public LevelHorse LevelHorse
	{
		 get { } //Length: 8
	}

	public LevelDragActionHorseHandlerBase() { }

	protected virtual void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public LevelHorse get_LevelHorse() { }

	private void HandleEnterByType(LevelHorseDraggingAreaHandler areaHandler) { }

	private void HandleExitByType(LevelHorseDraggingAreaHandler areaHandler, ExitReasonType exitReasonType) { }

	private void HandleJumpObstacleExit(ExitReasonType exitReasonType) { }

	protected virtual bool IsStrictInteractionTest() { }

	protected virtual void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

	protected void Start() { }

}

