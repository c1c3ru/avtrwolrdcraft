namespace Game.Level;

public class LevelPassportItemHandler : LevelDragActionItemHandlerBase
{

	public LevelPassportItemHandler() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

}

