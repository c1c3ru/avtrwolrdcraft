namespace PWC.Level;

public class LevelHorseDraggingAreaHandler : LevelConsumerAreaBase
{
	internal enum HorseDragAreaType
	{
		None = 0,
		JumpObstacle = 1,
	}

	[SerializeField]
	private HorseDragAreaType _areaType; //Field offset: 0x54
	public UnityEvent<LevelDragActionHorseHandlerBase> OnHorseEnterAction; //Field offset: 0x58
	public UnityEvent<LevelDragActionHorseHandlerBase> OnHorseExitAction; //Field offset: 0x60

	public HorseDragAreaType AreaType
	{
		 get { } //Length: 8
	}

	public LevelHorseDraggingAreaHandler() { }

	public HorseDragAreaType get_AreaType() { }

	public override void OnTargetEnter(LevelDragActionHorseHandlerBase levelDragActionHorseHandlerBase) { }

	public override void OnTargetExit(LevelDragActionHorseHandlerBase levelDragActionHorseHandlerBase) { }

}

