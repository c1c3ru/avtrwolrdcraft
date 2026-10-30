namespace Game.Level;

public class CurrentAvatarGroupHeldItemsLabelCondition : GenericConditionBase
{
	public List<String> expectedLabels; //Field offset: 0x10

	public CurrentAvatarGroupHeldItemsLabelCondition() { }

	private bool CheckItemLabel(LevelItem levelItem, string label) { }

	private bool CheckLabelOnHeldItem(LevelCharacter character, AvatarHandType handType, string label) { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

