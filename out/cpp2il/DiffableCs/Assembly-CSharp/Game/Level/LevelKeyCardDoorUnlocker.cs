namespace Game.Level;

public class LevelKeyCardDoorUnlocker : LevelDragActionItemHandlerBase
{

	public LevelKeyCardDoorUnlocker() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

}

