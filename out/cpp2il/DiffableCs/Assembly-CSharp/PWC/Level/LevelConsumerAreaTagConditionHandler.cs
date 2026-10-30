namespace PWC.Level;

public class LevelConsumerAreaTagConditionHandler : LevelConsumerAreaConditionBase
{
	[SerializeField]
	private LevelTagTestType _testType; //Field offset: 0x28
	[SerializeField]
	private LevelTagType[] _tags; //Field offset: 0x30

	public LevelConsumerAreaTagConditionHandler() { }

	protected virtual void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

}

