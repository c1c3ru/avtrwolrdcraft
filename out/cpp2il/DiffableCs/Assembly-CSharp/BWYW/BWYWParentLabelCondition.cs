namespace BWYW;

public class BWYWParentLabelCondition : BWYWConditionBase
{
	public string label; //Field offset: 0x10

	public BWYWParentLabelCondition() { }

	public virtual bool IsValid(ILevelAvatar avatar) { }

}

