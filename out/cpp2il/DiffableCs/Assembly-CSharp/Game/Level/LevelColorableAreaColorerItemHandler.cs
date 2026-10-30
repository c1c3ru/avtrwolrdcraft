namespace Game.Level;

public class LevelColorableAreaColorerItemHandler : LevelDragActionItemHandlerBase
{
	[SerializeField]
	private Color _color; //Field offset: 0xA0
	[SerializeField]
	private PWSpriteColorType _coloringType; //Field offset: 0xB0

	public LevelColorableAreaColorerItemHandler() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

}

