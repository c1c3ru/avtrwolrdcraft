namespace Game.Level;

public class CurrentTimeOfDayCondition : GenericConditionBase
{
	public TimeOfDay expectedTimeOfDay; //Field offset: 0x10

	public CurrentTimeOfDayCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

