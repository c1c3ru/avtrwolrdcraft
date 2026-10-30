namespace Game.Level;

public class CurrentActiveAvatarWornSkinCondition : GenericConditionBase
{
	public string skinName; //Field offset: 0x10

	public CurrentActiveAvatarWornSkinCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

