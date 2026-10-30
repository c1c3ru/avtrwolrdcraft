namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelTargetsSpawnerDragActionItemHandler : LevelDragActionItemHandlerBase
{
	[SerializeField]
	private string _soundName; //Field offset: 0xA0

	public LevelTargetsSpawnerDragActionItemHandler() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public virtual bool IsConsumerGoodTarget(ILevelConsumer consumer) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

}

