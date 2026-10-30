namespace PWC.Level;

public class LevelConsumerAreaSUTNameConditionHandler : LevelConsumerAreaConditionBase
{
	[SerializeField]
	private String[] _SUTNames; //Field offset: 0x28

	public LevelConsumerAreaSUTNameConditionHandler() { }

	protected virtual void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

}

