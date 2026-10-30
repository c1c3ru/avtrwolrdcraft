namespace Game.Level;

public class LevelColorerAreaColorableItemHandler : LevelDragActionItemHandlerBase
{
	[SerializeField]
	private LevelRuntimeColoredSpriteHandler _colorHandler; //Field offset: 0xA0
	[SerializeField]
	private PWSpriteColorType _coloringType; //Field offset: 0xA8
	[SerializeField]
	private bool _invokeEventOnPostInit; //Field offset: 0xAC
	[Header("Event On Getting Color")]
	[SerializeField]
	private UnityEvent<Color> _onGettingColor; //Field offset: 0xB0

	public LevelColorerAreaColorableItemHandler() { }

	protected virtual void Awake() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnDestroy() { }

	private void OnPostInitHandler() { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

}

