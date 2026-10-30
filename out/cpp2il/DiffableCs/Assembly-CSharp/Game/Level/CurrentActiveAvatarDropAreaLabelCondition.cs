namespace Game.Level;

public class CurrentActiveAvatarDropAreaLabelCondition : GenericConditionBase
{
	public string _dropAreaLabel; //Field offset: 0x10

	public CurrentActiveAvatarDropAreaLabelCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

