namespace Game.Level;

public class CurrentAvatarGroupWornSkinCondition : GenericConditionBase
{
	public string skinName; //Field offset: 0x10

	public CurrentAvatarGroupWornSkinCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

