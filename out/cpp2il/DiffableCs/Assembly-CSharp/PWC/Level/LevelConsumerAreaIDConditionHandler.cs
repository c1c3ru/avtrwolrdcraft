namespace PWC.Level;

public class LevelConsumerAreaIDConditionHandler : LevelConsumerAreaConditionBase
{
	[SerializeField]
	private Int32[] _IDs; //Field offset: 0x28
	[SerializeField]
	private bool _isDisallow; //Field offset: 0x30

	public LevelConsumerAreaIDConditionHandler() { }

	protected virtual void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

}

