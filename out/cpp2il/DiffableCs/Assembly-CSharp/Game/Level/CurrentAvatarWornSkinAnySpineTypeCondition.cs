namespace Game.Level;

public class CurrentAvatarWornSkinAnySpineTypeCondition : GenericConditionBase
{
	public string skinName; //Field offset: 0x10

	public CurrentAvatarWornSkinAnySpineTypeCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

	private bool IsWearingSkin(ILevelAvatar levelAvatar) { }

}

