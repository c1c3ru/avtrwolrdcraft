namespace PWC.Level;

public class LevelDragActionByLabelItemHandler : LevelDragActionItemHandlerBase
{
	private LevelLabelHandler _levelLabelHandler; //Field offset: 0xA0

	public LevelDragActionByLabelItemHandler() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	private void InitIfNeeded() { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

	private bool TryGetConsumerAsDragTarget(ILevelConsumer consumer, out ILevelDragActionLabelTarget target) { }

}

