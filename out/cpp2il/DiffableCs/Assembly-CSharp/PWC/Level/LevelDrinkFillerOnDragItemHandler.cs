namespace PWC.Level;

public class LevelDrinkFillerOnDragItemHandler : LevelDragActionItemHandlerBase
{
	[SerializeField]
	protected Color _color; //Field offset: 0xA0
	protected ILevelFillable _fillable; //Field offset: 0xB0
	[CompilerGenerated]
	private Action OnTargetFillAction; //Field offset: 0xB8

	public event Action OnTargetFillAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public LevelDrinkFillerOnDragItemHandler() { }

	[CompilerGenerated]
	public void add_OnTargetFillAction(Action value) { }

	protected virtual void Awake() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public virtual bool IsConsumerGoodTarget(ILevelConsumer consumer) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

	[CompilerGenerated]
	public void remove_OnTargetFillAction(Action value) { }

}

