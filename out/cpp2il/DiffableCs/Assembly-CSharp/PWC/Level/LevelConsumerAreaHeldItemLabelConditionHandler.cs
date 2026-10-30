namespace PWC.Level;

public class LevelConsumerAreaHeldItemLabelConditionHandler : LevelConsumerAreaConditionBase
{
	[SerializeField]
	private string _label; //Field offset: 0x28
	[SerializeField]
	private bool _isDisallow; //Field offset: 0x30

	public LevelConsumerAreaHeldItemLabelConditionHandler() { }

	protected virtual void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

	private bool CheckHand(LevelCharacter character, AvatarHandType handType) { }

	private bool IsHoldingLabeledItem(LevelItem levelItem) { }

}

