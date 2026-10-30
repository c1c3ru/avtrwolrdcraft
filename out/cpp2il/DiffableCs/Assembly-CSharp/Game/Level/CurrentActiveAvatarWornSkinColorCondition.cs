namespace Game.Level;

public class CurrentActiveAvatarWornSkinColorCondition : GenericConditionBase
{
	public CharacterCategoryType categoryType; //Field offset: 0x10
	public Color targetColor; //Field offset: 0x14

	public CurrentActiveAvatarWornSkinColorCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

