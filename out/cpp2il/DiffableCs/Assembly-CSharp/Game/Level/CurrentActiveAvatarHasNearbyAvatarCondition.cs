namespace Game.Level;

public class CurrentActiveAvatarHasNearbyAvatarCondition : GenericConditionBase
{
	public float _radius; //Field offset: 0x10
	public int _avatarID; //Field offset: 0x14
	public string _nearbyAvatarAnimationName; //Field offset: 0x18

	public CurrentActiveAvatarHasNearbyAvatarCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

