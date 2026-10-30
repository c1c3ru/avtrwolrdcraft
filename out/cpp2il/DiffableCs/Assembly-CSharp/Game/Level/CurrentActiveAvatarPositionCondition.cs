namespace Game.Level;

public class CurrentActiveAvatarPositionCondition : GenericConditionBase
{
	public float _minX; //Field offset: 0x10
	public float _maxX; //Field offset: 0x14

	public CurrentActiveAvatarPositionCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

