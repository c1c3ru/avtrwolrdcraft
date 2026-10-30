namespace PWC.Level;

public class LevelConsumerAreaConditionDenyID : LevelConsumerAreaConditionBase
{
	[SerializeField]
	private Int32[] _IDs; //Field offset: 0x28

	public LevelConsumerAreaConditionDenyID() { }

	protected virtual void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

}

