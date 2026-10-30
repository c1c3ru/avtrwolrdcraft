namespace PWC.Level;

public class LevelItemDropTagConditionHandler : LevelItemDropConditionBase
{
	[SerializeField]
	private LevelTagTestType _testType; //Field offset: 0x28
	[SerializeField]
	private LevelTagType[] _tags; //Field offset: 0x30

	public LevelItemDropTagConditionHandler() { }

	protected virtual void CanBeDroppedOn(LevelDropArea dropArea, ref bool canDrop) { }

}

