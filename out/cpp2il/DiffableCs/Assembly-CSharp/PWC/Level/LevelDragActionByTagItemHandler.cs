namespace PWC.Level;

public class LevelDragActionByTagItemHandler : LevelDragActionItemHandlerBase
{
	[SerializeField]
	private LevelTagType[] _tags; //Field offset: 0xA0
	[SerializeField]
	private LevelTagTestType _tagTestType; //Field offset: 0xA8

	public LevelDragActionByTagItemHandler() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

}

