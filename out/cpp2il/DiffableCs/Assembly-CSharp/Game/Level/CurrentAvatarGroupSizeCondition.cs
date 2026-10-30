namespace Game.Level;

public class CurrentAvatarGroupSizeCondition : GenericConditionBase
{
	internal enum ComparisonType
	{
		Equal = 0,
		GreaterThan = 1,
		LessThan = 2,
		GreaterOrEqual = 3,
		LessOrEqual = 4,
	}

	public int targetCount; //Field offset: 0x10
	public ComparisonType comparisonType; //Field offset: 0x14

	public CurrentAvatarGroupSizeCondition() { }

	public static bool Compare(int value, int target, ComparisonType type) { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

