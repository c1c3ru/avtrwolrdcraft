namespace Game.Level;

public class CurrentAvatarGroupWornSkinCategoryTypeCondition : GenericConditionBase
{
	public CharacterCategoryType categoryType; //Field offset: 0x10
	public bool allAvatarsRequireSkinCategoryType; //Field offset: 0x14

	public CurrentAvatarGroupWornSkinCategoryTypeCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

