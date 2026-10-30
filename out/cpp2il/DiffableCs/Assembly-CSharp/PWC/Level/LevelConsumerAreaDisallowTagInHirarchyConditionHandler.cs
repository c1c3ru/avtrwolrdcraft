namespace PWC.Level;

public class LevelConsumerAreaDisallowTagInHirarchyConditionHandler : LevelConsumerAreaConditionBase
{
	[SerializeField]
	private LevelTagType[] _tags; //Field offset: 0x28

	public LevelConsumerAreaDisallowTagInHirarchyConditionHandler() { }

	protected virtual void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

}

