namespace Game.Level;

public class LevelFishFoodFillerOnDragItemHandler : LevelDragActionItemHandlerBase
{
	[SerializeField]
	private Color _color; //Field offset: 0xA0
	private Coroutine _fillCoroutine; //Field offset: 0xB0

	public LevelFishFoodFillerOnDragItemHandler() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

}

