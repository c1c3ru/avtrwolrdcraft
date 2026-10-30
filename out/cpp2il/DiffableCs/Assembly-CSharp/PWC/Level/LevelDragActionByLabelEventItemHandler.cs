namespace PWC.Level;

public class LevelDragActionByLabelEventItemHandler : LevelDragActionItemHandlerBase
{
	[SerializeField]
	private string _label; //Field offset: 0xA0
	[SerializeField]
	private UnityEvent _onEnterAction; //Field offset: 0xA8
	[SerializeField]
	private UnityEvent _onExitAction; //Field offset: 0xB0

	public LevelDragActionByLabelEventItemHandler() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

}

