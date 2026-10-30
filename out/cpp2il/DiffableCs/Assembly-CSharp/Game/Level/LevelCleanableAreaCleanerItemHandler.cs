namespace Game.Level;

public class LevelCleanableAreaCleanerItemHandler : LevelDragActionItemHandlerBase
{

	public LevelCleanableAreaCleanerItemHandler() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

}

