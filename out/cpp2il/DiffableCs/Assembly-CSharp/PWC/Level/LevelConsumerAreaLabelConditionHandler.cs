namespace PWC.Level;

public class LevelConsumerAreaLabelConditionHandler : LevelConsumerAreaConditionBase
{
	[SerializeField]
	private string _label; //Field offset: 0x28
	[SerializeField]
	private bool _isDisallow; //Field offset: 0x30

	public LevelConsumerAreaLabelConditionHandler() { }

	protected virtual void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

}

