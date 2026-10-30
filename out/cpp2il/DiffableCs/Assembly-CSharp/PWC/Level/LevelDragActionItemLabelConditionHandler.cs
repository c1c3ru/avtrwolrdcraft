namespace PWC.Level;

public class LevelDragActionItemLabelConditionHandler : LevelDragActionItemConditionBase
{
	[SerializeField]
	private string _label; //Field offset: 0x28

	public LevelDragActionItemLabelConditionHandler() { }

	protected virtual void FilterTarget(ILevelConsumer target, ref bool canConsume) { }

}

