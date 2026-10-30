namespace Game.Level;

[AddComponentMenu(null)]
public class LevelTrainTicket : LevelSimpleDragActionItemBase
{

	public LevelTrainTicket() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer) { }

}

