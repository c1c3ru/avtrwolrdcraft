namespace Game.Level;

public class CurrentActiveAvatarWornSkinCategoryTypeCondition : GenericConditionBase
{
	public CharacterCategoryType categoryType; //Field offset: 0x10

	public CurrentActiveAvatarWornSkinCategoryTypeCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

