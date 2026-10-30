namespace Game.Level;

public class CurrentActiveAvatarIDCondition : GenericConditionBase
{
	public int _avatarID; //Field offset: 0x10

	public CurrentActiveAvatarIDCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

