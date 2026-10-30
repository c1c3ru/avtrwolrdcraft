namespace Game.Level;

public class LevelCoffeeFillerOnDragItemHandler : LevelDragActionItemHandlerBase
{

	public LevelCoffeeFillerOnDragItemHandler() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

}

