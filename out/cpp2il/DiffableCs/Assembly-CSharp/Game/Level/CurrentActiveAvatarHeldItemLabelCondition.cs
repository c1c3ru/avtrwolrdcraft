namespace Game.Level;

public class CurrentActiveAvatarHeldItemLabelCondition : GenericConditionBase
{
	public string expectedLabel; //Field offset: 0x10

	public CurrentActiveAvatarHeldItemLabelCondition() { }

	private bool CheckItemLabel(LevelItem levelItem) { }

	private bool CheckLabelOnHeldItem(LevelCharacter character, AvatarHandType handType) { }

	private bool CheckLabelOnHeldItem(LevelToddler toddler, AvatarHandType handType) { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

