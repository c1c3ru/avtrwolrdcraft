namespace PWC.Level;

public class LevelDragActionItemTagConditionHandler : LevelDragActionItemConditionBase
{
	[SerializeField]
	private LevelTagTestType _testType; //Field offset: 0x28
	[SerializeField]
	private LevelTagType[] _tags; //Field offset: 0x30

	public LevelDragActionItemTagConditionHandler() { }

	protected virtual void FilterTarget(ILevelConsumer target, ref bool canConsume) { }

}

